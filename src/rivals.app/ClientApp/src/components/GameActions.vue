<template>
  <div class="game-actions">
    <h1>Game Actions</h1>
    <game-action></game-action>
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
  h1 {
    color: antiquewhite;
  }
</style>
