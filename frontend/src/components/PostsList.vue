<script setup lang="ts">
import type { Post } from '@/models';
import { ref } from 'vue';
import { RouterLink } from 'vue-router';


const posts = ref<Post[]>([])
fetch('/api/posts')
    .then(response => response.json())
    .then(json => {
        posts.value = json
        console.log(json)
    }
    )

</script>

<template>
    <div v-for="post in posts" :key="post.postId" class="flex flex-col w-1/2 flex-wrap gap-2.5 bg-lime-50 p-5">
        <RouterLink :to="'/post/' + post.postId">
            <h2 class="va-h4">{{ post.heading }}</h2>
        </RouterLink>
        <RouterLink class="bg-lime-100 max-w-max rounded p-1" :to="'/user/' + post.userId">
            <p>{{ post.user }}</p>
        </RouterLink>
        <p>{{ post.postText }}</p>
        <RouterLink class="bg-slate-100 max-w-max rounded p-1" :to="'/topic/' + post.topicId">
            {{ post.topic }}
        </RouterLink>
    </div>
</template>
