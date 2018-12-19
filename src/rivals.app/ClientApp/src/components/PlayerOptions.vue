<template>
  <div class="player-options">
    <h1>Player Options</h1>
    <player-actions></player-actions>
    <game-actions></game-actions>
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
  h1 {
    color: darkgoldenrod;
  }
</style>
