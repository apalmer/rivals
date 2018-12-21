<template>
  <div class="game-action" v-on:click="decrement">
    <span>Game Action</span>
  </div>
</template>

<script>
export default {
  name: 'gameAction',
  components: {
  },
  props: {
  },
  methods: {
    decrement () {
      this.$store.dispatch('asyncDecrement', 9)
      this.$store.commit('players/damageProtagonist', 5)
      this.$store.dispatch('players/asyncDamageAntagonist', 10)
      this.$store.commit('players/increaseRange', 1)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .game-action {
    background-color: white;
    height: 5rem;
  }
</style>
