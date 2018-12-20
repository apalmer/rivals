<template>

  <div class="game-table">
    <span>Game Table</span>
    <div class="player-hand-container container">
      <player-hand></player-hand>
    </div>
    <div class="player-hand-container container">
      <player-hand></player-hand>
    </div>
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

  .game-table {
    background-color: lightgrey;
    padding: 1rem;
  }

  .player-hand-container {
    background-color: lightgrey;
  }

    .player-hand-container ~ .player-hand-container {
      padding-top: 1rem;
    }

</style>
