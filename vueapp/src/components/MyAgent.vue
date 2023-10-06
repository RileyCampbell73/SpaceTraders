<template>
    <h1>Agent Info</h1>
    <p>Designation: {{Agent.symbol}}</p>
    <p>Headquarters: {{Agent.headquarters}}</p>
    <p>Credits: {{Agent.credits}}</p>

</template>
    
<script setup>
    import { ref, watch } from 'vue'

    var Agent = ref({})

    const props = defineProps({
        _Agent: Object
    })
    watch(() => props._Agent, (data) => {
        Agent.value = data
    })   

</script>