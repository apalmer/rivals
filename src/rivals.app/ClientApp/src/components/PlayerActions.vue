<template>
  <div class="player-actions">
    <h1>Player Actions</h1>
    <player-action></player-action>
    <player-action></player-action>
    <player-action></player-action>
    <player-action></player-action>
    <player-action></player-action>
    <player-action></player-action>
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
  h1 {
    color: antiquewhite;
  }
</style>
