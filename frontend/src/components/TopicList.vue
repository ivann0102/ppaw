//list of topics
<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
import { Topic } from '@/models';

const topics = ref<Topic[]>([])
fetch('/api/Topics')
    .then(response => response.json())
    .then(json => {
        topics.value = json
        console.log(json)
    }
    )

</script>

<template>
    <div class="flex flex-row gap-5 justify-center mt-2 w-1/4 flex-wrap">
        <RouterLink class="bg-lime-100 max-w-max rounded p-1" v-for="topic in topics" :key="topic.topicId"
            :to="'/topic/' + topic.topicId">
            {{ topic.topicName }}
        </RouterLink>
    </div>
</template>
