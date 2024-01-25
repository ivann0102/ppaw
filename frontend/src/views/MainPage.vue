<script setup lang="ts">
import TopicList from "@/components/TopicList.vue";
import PostsList from "@/components/PostsList.vue";
import CreatePost from "@/components/CreatePost.vue";
import CreateTopic from "@/components/CreateTopic.vue";
import { ref } from "vue";

const images = ref<string[]>([])
const role = localStorage.getItem('user_role')

</script>
<template>
  <div class="w-full grid grid-flow-row place-items-center gap-10">
    <TopicList />
    <CreatePost v-model:images="images" />
    <CreateTopic v-if="role == 'Admin'"></CreateTopic>
    <p>{{ images }}</p>
    <PostsList />
  </div>
</template>
