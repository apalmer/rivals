<template>
  <div class="player-options">
    <span>Player Options</span>
    <div class="player-actions-container row">
      <player-actions></player-actions>
    </div>
    <div class="game-actions-container row">
      <game-actions></game-actions>
    </div>
  </div>
</template>

<script>
import PlayerActions from '@/components/PlayerActions.vue'
import GameActions from '@/components/GameActions.vue'

export default {
  name: 'playerOptions',
  components: {
    PlayerActions,
    GameActions
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .player-options {
    background-color: darkgrey;
    padding: 1rem;
  }
  .player-actions-container {
  }
  .game-actions-container {
    padding-left: 1rem;
    padding-right: 1rem;
  }
</style>
