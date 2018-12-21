<template>
  <div class="game-status">
    <span>Game Status</span>
    <h1>{{longerRoundTime}}</h1>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  name: 'gameStatus',
  props: {
  },
  computed: {
    longerRoundTime() {
      return this.$store.getters.longerRoundTime(40)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .game-status {
    background-color: grey;
    height: 5rem;
  }
</style>
