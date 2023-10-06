<template>
    <h2>Ships</h2>
    <div>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">ShipID</th>
                    <th scope="col">Type</th>
                    <th scope="col">Location</th>
                    <th scope="col">Fuel</th>
                    <th scope="col">Cargo</th>
                    <th scope="col">Status</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <template v-for="ship in Ships" :key="ship.symbol">
                    <tr @click="toggleSubRow(ship.symbol, ship.nav.waypointSymbol)" scope="row">
                        <td>{{ship.symbol}}</td>
                        <td>{{ship.frame.name}}</td>
                        <td>{{ship.nav.waypointSymbol}}</td>
                        <td>{{ship.fuel.current}}({{ship.fuel.capacity}})</td>
                        <td>{{ship.cargo.units}}({{ship.cargo.capacity}})</td>
                        <td>{{ship.nav.status}}</td>
                        <td>Arrival: {{ship.nav.route.arrival}}</td>
                    </tr>
                    <tr v-if="Opened.includes(ship.symbol)">
                        <td colspan="7">
                            <button v-if="ship.nav.status == 'IN_ORBIT'" type="button" class="btn btn-primary" @click="Dock(ship.symbol)">Dock</button>
                            <button v-else type="button" class="btn btn-primary" @click="Orbit(ship.symbol)">Orbit</button>
                            <button v-if="ship.nav.status == 'DOCKED'" type="button" class="btn btn-primary" @click="Refuel(ship.symbol)">Refuel</button>
                            <button type="button" class="btn btn-primary" @click="Extract(ship.symbol)">Extract</button>
                            <hr />
                            <h4>Inventory</h4>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">Name</th>
                                        <th scope="col">Units</th>
                                        <th scope="col">Description</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <template v-if="Waypoint">
                                        <tr v-for="inv in ship.cargo.inventory" :key="inv.symbol" scope="row">
                                            <td>{{inv.name}}</td>
                                            <td>{{inv.units}}</td>
                                            <td>{{inv.description}}</td>
                                            <td> <button v-if="HasTrait('MARKETPLACE')" type="button" class="btn btn-primary" @click="SellGoods(ship.symbol, inv.symbol, inv.units)">Sell</button> </td>
                                        </tr>
                                    </template>
                                </tbody>
                            </table>

                        </td>
                    </tr>
                </template>
            </tbody>
        </table>
    </div>
</template>

<script setup>
    import { ref, watch } from 'vue'

    const emit = defineEmits(['update_agent'])

    var Ships = ref()
    var Waypoint = ref()

    const props = defineProps({
        _Ships: Array
    })
    watch(() => props._Ships, (data) => {
        Ships.value = data
    })

    var Opened = ref([])

    function toggleSubRow(ID, waypoint) {
        const index = Opened.value.indexOf(ID);
        if (index > -1) {
            Opened.value.splice(index, 1)
        } else {
            fetch('systems/waypoint?waypointId=' + waypoint)
                .then(r => r.json())
                .then(json => { Waypoint.value = json.data });

            Opened.value.push(ID)
        }
    }

    function HasTrait(traitSymbol) {
        return Waypoint.value.traits.filter(function (trait) { return trait.symbol == traitSymbol; }).length > 0
    }

    function Dock(shipId) {
        const requestOptions = {
            method: "POST"
        };

        fetch('ships/dockship?shipid=' + shipId, requestOptions)
            .then(r => r.json())
            .then(json => {
                var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                Ships.value[shipIndex].nav = json.data.nav;
            })
    }

    function Refuel(shipId) {
        const requestOptions = {
            method: "POST"
        };

        fetch('ships/refuel?shipid=' + shipId, requestOptions)
            .then(r => r.json())
            .then(json => {
                var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                Ships.value[shipIndex].fuel = json.data.fuel;
                emit('update_agent', json.data.agent)
            })
    }

    function Orbit(shipId) {
        const requestOptions = {
            method: "POST"
        };

        fetch('ships/orbit?shipid=' + shipId, requestOptions)
            .then(r => r.json())
            .then(json => {
                var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                Ships.value[shipIndex].nav = json.data.nav;

            })
    }

    function Extract(shipId) {
        const requestOptions = {
            method: "POST"
        };

        fetch('ships/extract?shipid=' + shipId, requestOptions)
            .then(r => r.json())
            .then(json => {
                var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                Ships.value[shipIndex].cargo = json.data.cargo;

            })
    }

     function SellGoods(shipId, Good, Units) {
        const requestOptions = {
            method: "POST"
        };

        fetch('ships/sell?shipid=' + shipId + '&resource=' + Good + '&units=' + Units, requestOptions)
            .then(r => r.json())
            .then(json => {
                var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                Ships.value[shipIndex].cargo = json.data.cargo;
                emit('update_agent', json.data.agent)
            })
    }

</script>