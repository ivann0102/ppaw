import { createRouter, createWebHistory } from "vue-router";
import Posts from "@/views/PostsTable.vue";
import MainPage from "@/views/MainPage.vue";
import LogInPage from "@/views/LogInPage.vue";

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
{
      path: "/login",
      name: "login",
      component: LogInPage,
    },
  ],
});

export default router;
