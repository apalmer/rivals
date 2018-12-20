<template>
  <div class="player-actions col-md-12">
    <span>Player Actions</span>
    <div class="row">
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
      <div class="player-action-container col-md-2">
        <player-action></player-action>
      </div>
    </div>
  </div>
</template>

<script>
import PlayerAction from '@/components/PlayerAction.vue'

export default {
  name: 'playerActions',
  components: {
    PlayerAction
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .player-actions{

  }
  .player-action-container {
    padding: 1rem;
  }
</style>
