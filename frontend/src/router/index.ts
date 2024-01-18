import { createRouter, createWebHistory } from "vue-router";
import Posts from "@/views/PostsTable.vue";
import MainPage from "@/views/MainPage.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/posts",
      name: "posts",
      component: Posts,
    },
    {
      path: "/",
      name: "home",
      component: MainPage,
    },

  ],
});

export default router;
