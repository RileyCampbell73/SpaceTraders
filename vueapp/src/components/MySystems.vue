

<script setup>
    import { ref, reactive, onMounted, watch } from 'vue'
    import { Modal } from 'bootstrap'

    var Systems = ref([])
    var Ships = ref([])

    const props = defineProps({
        _Systems: Array,
        _Ships: Array
    })
    watch(() => props._Systems, (data) => {
        Systems.value = data
    })
    watch(() => props._Ships, (data) => {
        Ships.value = data
    })

    var Waypoints = ref([])
    var purchasableShips = ref([])
    var currentWaypoint = ref()

    var Opened = ref([])

    const emit = defineEmits(['agent', 'newShip'])

    function HasTrait(waypoint, traitSymbol) {
        return waypoint.traits.filter(function (trait) { return trait.symbol == traitSymbol; }).length > 0
    }

    function toggleSubRow(ID) {
        const index = Opened.value.indexOf(ID);
        if (index > -1) {
            Opened.value.splice(index, 1)
        } else {
            Opened.value.push(ID)

            //fetch waypoint data
            fetch('systems/waypoints?system=' + ID)
                .then(r => r.json())
                .then(json => { Waypoints.value = json.data })
        }
    }

    //var showShipyardModal = ref(false)
    var showNavShipModal = ref(false)

    const state = reactive({
        modal_shipyard: null,
        modal_navShip: null
    })

    onMounted(() => {
        state.modal_shipyard = new Modal('#Shipyard_Modal', {});
        state.modal_navShip = new Modal('#NavShip_Modal', {});
    })

    function openModal(waypoint) {
        //fetch shipyard data
        currentWaypoint = waypoint;

        fetch('systems/shipyard?waypoint=' + waypoint)
            .then(r => r.json())
            .then(json => { purchasableShips.value = json.data.shipTypes })
        state.modal_shipyard.show()
    }

    function closeModal() {
        state.modal_shipyard.hide()
    }

    function openNavModal(waypoint) {
        //fetch shipyard data
        currentWaypoint = waypoint;
        showNavShipModal.value = true;
       
        state.modal_navShip.show()
    }

    function closeNavModal() {
        state.modal_navShip.hide()
        showNavShipModal.value = false;
    }

    function purchaseShip(ShipType, waypoint) {
        const requestOptions = {
            method: "POST"
        };

        fetch('systems/purchaseShip?shiptype=' + ShipType + '&waypoint=' + waypoint, requestOptions)
            .then(r => r.json())
            .then(json => { emit('agent', json.data.agent), emit('newShip', json.data.ship) })

        //Close modal & return success message. Also refresh ships table
    }

    var selectShip = ref();

    function navShip(waypoint) {

        var shipId = selectShip.value;

        const requestOptions = {
            method: "POST"
        };

        fetch('ships/navShip?shipid=' + shipId + '&waypoint=' + waypoint, requestOptions)
            .then(r => r.json())
            //.then(json => { })

        //Close modal & return success message. Also refresh ships table
    }

    //function updateshiplist() {

    //}

   
    
</script>


<template>
    <h2>Systems</h2>
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">Sector</th>
                <th scope="col">System</th>
                <th scope="col">Waypoints</th>

            </tr>
        </thead>
        <tbody>
            <template v-if="Systems">
                <template v-for="sys in Systems" :key="sys.symbol">
                    <tr @click="toggleSubRow(sys.symbol)" scope="row">
                        <td>{{sys.sectorSymbol}}</td>
                        <td>{{sys.symbol}}</td>
                        <td>{{sys.waypoints.length}}</td>

                    </tr>
                    <tr v-if="Opened.includes(sys.symbol)">
                        <td colspan="3">

                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">Waypoint</th>
                                        <th scope="col">Type</th>
                                        <th scope="col"></th>
                                        <th scope="col"></th> <!--Market-->
                                        <th scope="col"></th> <!--Shipyard-->
                                    </tr>
                                </thead>
                                <tbody>
                                    <template v-if="Waypoints">
                                        <template v-for="ways in Waypoints" :key="ways.symbol">
                                            <tr v-if="ways.systemSymbol = sys.symbol" scope="row">
                                                <td>{{ways.symbol}}</td>
                                                <td>{{ways.type}}</td>
                                                <td>
                                                    <button type="button" class="btn btn-primary" @click="openNavModal(ways.symbol)">NAV</button>
                                                </td>
                                                <td>
                                                    <button v-if="HasTrait(ways, 'MARKETPLACE')" type="button" class="btn btn-primary">MARKETPLACE</button>
                                                </td>
                                                <td>
                                                    <button v-if="HasTrait(ways, 'SHIPYARD')" type="button" class="btn btn-primary" @click="openModal(ways.symbol)">SHIPYARD</button>
                                                </td>
                                            </tr>
                                        </template>
                                    </template>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </template>
            </template>
        </tbody>
    </table>

    <!-- Shipyard Modal -->
    <div class="modal fade" id="Shipyard_Modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ships for purchase</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" @click="closeModal()"></button>
                </div>
                <div class="modal-body">

                    <ul>
                        <li v-for="ship in purchasableShips" :key="ship.type">{{ship.type}} <button type="button" class="btn btn-primary" @click="purchaseShip(ship.type, currentWaypoint)">Purchase</button></li>
                    </ul>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" @click="closeModal()">Close</button>
                    <!--<button type="button" class="btn btn-primary">Save changes</button>-->
                </div>
            </div>
        </div>
    </div>

    <!-- Nav Ship Modal -->
    <div class="modal fade" id="NavShip_Modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" >
        <div class="modal-dialog">
            <div class="modal-content" v-if="showNavShipModal">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Choose ship to nav</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" @click="closeNavModal()"></button>
                </div>
                <div class="modal-body">

                    <select v-model="selectShip">
                        <option v-for="ship in Ships" :key="ship.type">{{ship.symbol}}</option>
                    </select>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" @click="closeNavModal()">Close</button>
                    <button type="button" class="btn btn-primary" @click="navShip(currentWaypoint)">Nav</button>
                </div>
            </div>
        </div>
    </div>
</template>
