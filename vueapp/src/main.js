import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"

const app = createApp(App)

var globalVariable;
app.provide('myGlobalVariable', globalVariable)

app.mount('#app')
