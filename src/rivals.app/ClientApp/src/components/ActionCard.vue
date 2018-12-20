<template>
  <div v-bind:class="[ mini ? 'action-card-mini' : 'action-card' ]">
    <span>Action Card</span>
  </div>
</template>

<script>
export default {
  name: 'actionCard',
  props: {
    mini: Boolean
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .action-card {
    height: 10rem;
    background-color: white;
  }
  .action-card-mini {
    height: 2rem;
    background-color: #ececec;
  }
</style>
