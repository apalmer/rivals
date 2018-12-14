<template>
  <div class="online-user" v-on:click="clickUser(user)" >{{user.userName}}
  </div>
</template>

<script>
export default {
  name: 'OnlineUser',
  props: {
    user: Object
  },
  data: function () {
    return {
    }
  },
  methods: {
    clickUser: function (user) {
      this.$root.$emit('challenge-user', user)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.online-user:hover{
  font-weight:bold
}
</style>
