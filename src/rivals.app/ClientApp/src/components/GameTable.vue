<template>
  <div class="game-table">
    <h1>Start Game Table</h1>
    <player-hand></player-hand>
    <player-hand></player-hand>
  </div>
</template>

<script>
  import PlayerHand from '@/components/PlayerHand.vue'

  export default {
    name: 'gameTable',
    components: {
      PlayerHand
    },
    props: {
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1 {
  color: #42b983;
}
</style>
