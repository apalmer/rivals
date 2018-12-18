<template>
  <div class="player-options">
    <h1>Player Options</h1>
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
    name: 'playerOptions',
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
    color: darkgoldenrod;
  }
</style>
