<template>
  <div class="duel">
    <h1>This is a duel between Rivals!</h1>
    <player-status player="opponent" layout="right-to-left"></player-status>
    <game-status></game-status>
    <player-status player="player" layout="left-to-right"></player-status>
    <game-table></game-table>
    <duel-range></duel-range>
    <player-options></player-options>
  </div>
</template>

<script>
  // @ is an alias to /src
  import GameTable from '@/components/GameTable.vue'
  import GameStatus from '@/components/GameStatus.vue'
  import PlayerStatus from '@/components/PlayerStatus.vue'
  import DuelRange from '@/components/DuelRange.vue'
  import PlayerOptions from '@/components/PlayerOptions.vue'

  export default {
    name: 'duel',
    components: {
      GameTable,
      GameStatus,
      PlayerStatus,
      DuelRange,
      PlayerOptions
    },
    data: function () {
      return {
      }
    },
    methods: {
    },
    mounted() {
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1 {
    color: aquamarine
  }

</style>
