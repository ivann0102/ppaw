<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { User, Post, Topic } from '@/models';



const posts = ref<Post[]>([])
const showModalEdit = ref(false)
const showModalDelete = ref(false)
const showModalCreate = ref(false)
const postIndex = ref(0)
const editedItem = ref<Post>(new Post())
const createdItem = ref<Post>(new Post())
const users = ref<User[]>()
const topics = ref<Topic[]>()

const columns = [
  { key: "postId" },
  { key: "heading" },
  { key: "postText" },
  { key: "postDate" },
  { key: "topicId" },
  { key: "userId" },
  { key: "parentPostId" },
  { key: "actions" },
]
function openModalToEditItemById(index: number) {
  postIndex.value = index
  editedItem.value = { ...posts.value[index] }
  showModalEdit.value = !showModalEdit.value
}

function openModalToDeleteItemById(index: number) {
  postIndex.value = index
  showModalDelete.value = !showModalDelete.value
}

function openModalToCreatePost() {
  showModalCreate.value = !showModalCreate.value
}

const editItem = () => {
  fetch(`/api/posts/${posts.value[postIndex.value].postId}`, {
    method: "put",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(editedItem.value)
  }).then((response) => console.log(response.status))

  alert(editedItem.value.postDate)
}

const deleteItem = () => {
  fetch(`/api/Posts/${posts.value[postIndex.value].postId}`, {
    method: "delete",
  }).then((response) => console.log(response.status))

  alert(posts.value[postIndex.value].postId)
}

const createItem = () => {
  fetch('/api/Posts/1', {
    method: "post",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(createdItem.value)
  }).then((response) => console.log(response.status))
}
fetch('/api/Posts')
  .then(response => response.json())
  .then(json => {
    posts.value = json
    console.log(json)
  }
  )

onMounted(() => {
  fetch('/api/Users')
    .then(response => response.json())
    .then(json => {
      users.value = json
      console.log(json)
    }
    )

  fetch('/api/Topics')
    .then(response => response.json())
    .then(json => {
      topics.value = json
      console.log(json)
    }
    )
})
</script>
<template>
  <div class="flex flex-col w-full items-center">
    <VaButton class="w-1/12" @click="openModalToCreatePost()">
      Create post
    </VaButton>
    <VaDataTable :items="posts" :columns="columns">
      <template #cell(actions)="{ rowIndex }">
        <VaButton preset="plain" icon="edit" @click="openModalToEditItemById(rowIndex)" />
        <VaButton preset="plain" icon="delete" @click="openModalToDeleteItemById(rowIndex)" />
      </template>
    </VaDataTable>

    <VaModal v-model="showModalEdit" ok-text="Apply" close-button @ok="editItem()">
      <h3 class="va-h3">
        Edit post
      </h3>
      <div class="w-full flex flex-col gap-5">
        <VaInput v-model="editedItem.heading" label="Heading" />
        <VaInput v-model="editedItem.postText" label="Post text" />
        <VaInput v-model="editedItem.topicId" label="Topic id" type="number" />
        <VaInput v-model="editedItem.userId" label="User id" type="number" />
        <VaInput v-model="editedItem.parentPostId" label="Parent post id" type="number" />
        <VaDateInput v-model="editedItem.postDate" label="Date" />
        <p>{{ editedItem.postDate }}</p>
      </div>
    </VaModal>

    <VaModal v-model="showModalCreate" ok-text="Apply" close-button @ok="createItem()">
      <h3 class="va-h3">
        Create post
      </h3>
      <div class="w-full flex flex-col gap-5">
        <VaInput v-model="createdItem.heading" label="Heading" />
        <VaInput v-model="createdItem.postText" label="Post text" />
        <VaDateInput v-model="createdItem.postDate" label="Date" />
        <VaInput v-model="createdItem.topicId" label="Topic id" type="number" />
        <VaInput v-model="createdItem.userId" label="User id" type="number" />
        <VaInput v-model="createdItem.parentPostId" label="Parent post id" type="number" />
      </div>
    </VaModal>

    <VaModal v-model="showModalDelete" ok-text="Apply" close-button @ok="deleteItem()">
      <h3 class="va-h3">
        Delete post
      </h3>
      <div class="w-full flex flex-col gap-5">
        <p>Are you sure?</p>
      </div>
    </VaModal>
  </div>
</template>
