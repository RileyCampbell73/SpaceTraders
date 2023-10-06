<template>
    <h2>Contracts</h2>
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">Accepted</th>
                <th scope="col">Type</th>
                <th scope="col">Cred on Accept</th>
                <th scope="col">Cred on Fullfillment</th>
                <th scope="col">Expiration</th>

            </tr>
        </thead>
        <tbody>
            <template v-if="Contracts">
                <template v-for="cont in Contracts" :key="cont.id">
                    <tr @click="toggleSubRow(cont.id)" scope="row">
                        <td>{{cont.accepted}}</td>
                        <td>{{cont.type}}</td>
                        <td>{{cont.terms.payment.onAccepted}}</td>
                        <td>{{cont.terms.payment.onFulfilled}}</td>
                        <td>{{cont.expiration}}</td>

                        <!--<td v-if="cont.accepted">{{cont.terms.deliver.unitsRequired}}({{cont.terms.deliver.unitsRequired}}) {{cont.terms.deliver.tradeSymbol}}</td>
                        <td v-else>{{cont.terms.deliver.unitsRequired}} {{cont.terms.deliver.tradeSymbol}}</td>-->
                        <!--This is an array - move it to sub row-->

                    </tr>
                    <tr v-if="Opened.includes(cont.id)">
                        <td colspan="5">
                            <button v-if="!cont.accepted" type="button" class="btn btn-primary" @click="acceptContract(cont.id)">Accept</button>

                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">Good</th>
                                        <th scope="col">Destination</th>
                                        <th scope="col">Units</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <template v-for="goods in cont.terms.deliver" :key="goods.tradeSymbol">
                                        <tr scope="row">
                                            <td>{{goods.tradeSymbol}}</td>
                                            <td>{{goods.destinationSymbol}}</td>
                                            <td>{{goods.unitsFulfilled}}/{{goods.unitsRequired}}</td>
                                        </tr>
                                    </template>
                                </tbody>
                            </table>

                        </td>
                    </tr>
                </template>
            </template>
        </tbody>
    </table>



</template>

<script setup>
    import { ref, watch } from 'vue'

    var Contracts = ref()

    const props = defineProps({
        _Contracts: Array
    })
    watch(() => props._Contracts, (data) => {
        Contracts.value = data
    })


    var Opened = ref([])


    function toggleSubRow(ID) {
        const index = Opened.value.indexOf(ID);
        if (index > -1) {
            Opened.value.splice(index, 1)
        } else {
            Opened.value.push(ID)
        }
    }

    function acceptContract(ID) {
        const requestOptions = {
            method: "POST"
        };

        fetch('contracts/acceptcontract?contractid=' + ID, requestOptions)
            .then(r => r.json())
            .then(json => {
                //emit('agent', json.data.agent),//broken -> fix later. Call still went through, need more contracts to test w. **is data an array?**
                    Contracts.value[Contracts.value.indexOf(json.data.contract)].value = json.data.contract
            })
    }



</script>

