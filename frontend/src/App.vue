<script setup lang="ts">
import { RouterView } from 'vue-router'

const user = localStorage.getItem('user_id')
</script>

<template>
  <VApp class="flex w-full h-full flex-col">
    <VaNavbar color="#282F69" class="va-h24">
      <template #left>
        <VaNavbarItem class="logo">
          Forum
        </VaNavbarItem>
      </template>
      <template #right>
        <VaNavbarItem class="hidden sm:block">
          Dashboard
        </VaNavbarItem>
        <VaNavbarItem class="hidden sm:block">
          <span v-if="user == null">LogIn</span>
          <span v-if="user != null">LogOut</span>
        </VaNavbarItem>
      </template>
    </VaNavbar>
    <RouterView />
  </VApp>
</template>

<style scoped>
body {
  width: 100%;
}
</style>
