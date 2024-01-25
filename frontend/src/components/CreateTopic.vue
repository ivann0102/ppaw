<script setup lang="ts">
import { Post, Topic } from '@/models';
import { ref } from 'vue';

const topic = ref<Topic>(new Topic())
// const images = ref<string[]>([])

function createPost() {
    let userId: number = localStorage.getItem("user_id") == null ? -1 : Number(localStorage.getItem("user_id"))
    console.log(JSON.stringify(topic.value))
    fetch(`/api/Topics/${userId}`, {
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(topic.value)
    }).then((response) => {
        console.log(response.status)
        clear()
    })
}

function clear() {
    topic.value = new Topic()
}

</script>
<template>
    <div class="flex flex-col gap-5 justify-center p-5 w-1/2 shadow-lg m-auto bg-lime-50">
        <h2 class="va-h4">Create Topic</h2>
        <VaInput v-model="topic.topicName" label="Topic Name" class="w-full" />
        <VaButton @click="createPost">Create</VaButton>
    </div>
</template>