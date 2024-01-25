<script setup lang="ts">
import { LoginModel } from '@/models';
import { ref } from 'vue';

const username = ref<string>()
const password = ref<string>()

function logIn() {
    let loginModel: LoginModel = new LoginModel()
    loginModel.password = password.value
    loginModel.userName = username.value
    fetch(`/api/Users/login`, {
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginModel)
    }).then((response)=>response.json()).then((json) => {
        localStorage.setItem("user_id", json.userId)
        localStorage.setItem("user_role", json.role)
        clear()
    })
}

function clear() {
    username.value = ""
    password.value = ""
}

</script>
<template>
    <div class="w-full h-full mt-20">
        <div class="flex flex-col gap-5 p-2 w-1/2 shadow-lg bg-lime-50 ml-auto mr-auto mt-">
            <h2 class="va-h4">Log In</h2>
            <VaInput v-model="username" label="username" />
            <VaInput v-model="password" type="password" label="password" />
            <VaButton @click="logIn">Log In</VaButton>
        </div>
    </div>
</template>
