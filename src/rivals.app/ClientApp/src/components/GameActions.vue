<template>
  <div class="game-actions col-md-12">
    <span>Game Actions</span>
    <div class="game-action-container">
      <game-action></game-action>
    </div>
    <div class="game-action-container">
      <game-action></game-action>
    </div>
  </div>
</template>

<script>
import GameAction from '@/components/GameAction.vue'

export default {
  name: 'gameActions',
  components: {
    GameAction
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .game-actions{

  }
  .game-action-container {
  }
</style>
