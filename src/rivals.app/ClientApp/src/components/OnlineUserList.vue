<template>
  <div class="online-user-list">
    <OnlineUser v-for="user in users" v-bind:user="user" v-on:challenge-user="challenge"></OnlineUser>
  </div>
</template>

<script>
  import OnlineUser from '@/components/OnlineUser.vue'

  export default {
    name: 'OnlineUserList',
    components: {
      OnlineUser
    },
    props: {
      users: Array
    },
    methods: {
      challenge: function (user) {
        alert(`challenged in user list!! ${user.userName}`);
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
