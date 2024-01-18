// recent posts
// list of topics
// create post
<script setup lang="ts">
import TopicList from "@/components/TopicList.vue";
import PostsList from "@/components/PostsList.vue";
import CreatePost from "@/components/CreatePost.vue";
import { ref } from "vue";

const images = ref<string[]>([])

</script>
<template>
  <div class="w-full grid grid-flow-row place-items-center gap-10">
    <TopicList />
    <CreatePost v-model:images="images" />
    <p>{{ images }}</p>
    <PostsList />
  </div>
</template>
