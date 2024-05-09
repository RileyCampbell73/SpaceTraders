<template>
    <!--<img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>-->
    <!--<div v-show="NewAgentRequired">-->
    <div v-show="NewAgentRequired">
        <button @click="createAgent(Deeve_Stanger)">Create New Agent</button>
    </div>
    
    <MyAgent :_Agent="Agent_data" ></MyAgent>
    <Ships 
           :_Ships="Ships_data"

           @update_agent="(agent) => Agent_data = agent"
           >
    </Ships>
    <Contracts :_Contracts="Contracts_data"></Contracts>
    <hr/>
    <Systems 
             :_Systems="Systems_data" 
             :_Ships="Ships_data"
             
             @agent="(agent) => Agent_data = agent"
             @newShip="(ship) => Ships_data.push(ship)"
             >
    </Systems>
</template>   

<script setup>
    import { ref } from 'vue'
    import MyAgent from './components/MyAgent.vue'
    import Ships from './components/MyShips.vue'
    import Contracts from './components/MyContracts.vue'
    import Systems from './components/MySystems.vue'


    
    var Agent_data = ref([])
    var Ships_data = ref([])
    var Contracts_data = ref([])
    var Systems_data = ref([])

    var NewAgentRequired = ref(false);
    getAgentData();

    function getAgentData() {
        //get data
        fetch('agent')
            .then(r => r.json())
            .then(json => {
                switch (json.ResponseCode) {
                    case 12:
                        alert(json.Message)
                        NewAgentRequired.value = true;
                        break;
                    default:
                        Agent_data.value = json.data;
                        getShips()
                        getContracts()
                        getSystems()
                        break;
                }
            })
    }

    function createAgent(name) {
        name = "Deeve_Stanger"
        const requestOptions = {
            method: "POST"
        };

        fetch('agent/register?faction=' + "COSMIC" + '&name=' + "Deeve_Stanger" + '&email=' + "riley.campbell73@gmail.com", requestOptions)
            .then(r => r.json())
            .then(json => {
                debugger

                //if success
                //refresh agentdata
                //get everything else

                //var shipIndex = Ships.value.map(e => e.symbol).indexOf(shipId);
                //Ships.value[shipIndex].cargo = json.data.cargo;
                //emit('update_agent', json.data.agent)
            })
            
    }

    function getShips(){
        fetch('ships')
        .then(r => r.json())
        .then(json => { Ships_data.value = json.data })

    }
    function getContracts(){
        fetch('contracts')
        .then(r => r.json())
        .then(json => { Contracts_data.value = json.data })
    }
    function getSystems(){
        fetch('systems')
        .then(r => r.json())
        .then(json => { Systems_data.value = json.data })

    }

    

    

  
        


</script>

<style>
/*#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}*/
</style>
