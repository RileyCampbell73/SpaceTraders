<template>
    <!--<img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>-->
    <MyAgent :_Agent="Agent_data"></MyAgent>
    <Ships 
           :_Ships="Ships_data"

           @update_agent="(agent) => Agent_data = agent"
           ></Ships>
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

    //get data
    fetch('agent')
        .then(r => r.json())
        .then(json => { Agent_data.value = json.data })

    fetch('ships')
        .then(r => r.json())
        .then(json => { Ships_data.value = json.data })

    fetch('contracts')
        .then(r => r.json())
        .then(json => { Contracts_data.value = json.data })

    //fetch('systems')
    //    .then(r => r.json())
    //    .then(json => { Systems_data.value = json.data })

        


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
