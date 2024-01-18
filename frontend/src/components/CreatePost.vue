<script setup lang="ts">
import { Post, Topic } from '@/models';
import { onMounted, ref } from 'vue';

const topics = ref<Topic[]>([])
const topic = ref<Topic>()
const text = ref<string>()
const heading = ref<string>()
const images = defineModel<string[]>("images", { default: [] })
// const images = ref<string[]>([])
onMounted(() => {
    fetch('/api/Topics')
        .then(response => response.json())
        .then(json => {
            topics.value = json
            console.log(json)
        })
})

function createPost() {
    let post: Post = new Post();
    if (heading.value != undefined)
        post.heading = heading.value
    if (topic.value != undefined)
        post.topicId = topic.value.topicId
    if (text.value != undefined)
        post.postText = text.value
    post.userId = 1
    post.images = images.value
    fetch(`/api/Posts/${post.userId}`, {
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(post)
    }).then((response) => console.log(response.status))
}
</script>
<template>
    <div class="flex flex-col gap-5 justify-center p-5 w-1/2 shadow-lg m-auto bg-lime-50">
        <h2 class="va-h4">Create Post</h2>
        <VaInput v-model="heading" label="Heading" class="w-full" />
        <VaTextarea v-model="text" label="Post Text" class="w-full" />
        <VaSelect v-model="topic" :options="topics" :text-by="(option: Topic) => option.topicName"
            placeholder="Select topic..." />
        <VaInput v-for="(image, index) in images" v-model="images[index]" :key="index"></VaInput>
        <VaButton class="w-max" @click="images.push('')">Add Image</VaButton>
        <VaButton @click="createPost">Create</VaButton>
    </div>
</template>