<template>
  <div>
    <div class="container">

      <div class="row">
        <div class="col-md-5 player-status-container player-status-container-left">
          <player-status v-bind:reverseLayout="true" v-bind:player="antagonist"></player-status>
        </div>
        <div class="col-md-2 game-status-container">
          <game-status ></game-status>
        </div>
        <div class="col-md-5 player-status-container player-status-container-right">
          <player-status v-bind:player="protagonist"></player-status>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-md-12 duel-range-container">
          <duel-range></duel-range>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-md-12 game-table-container">
          <game-table></game-table>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="player-options-container col-md-12">
          <player-options></player-options>
        </div>
      </div>
      <!-- /.row -->

    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import GameStatus from '@/components/GameStatus.vue'
import PlayerStatus from '@/components/PlayerStatus.vue'
import DuelRange from '@/components/DuelRange.vue'
import GameTable from '@/components/GameTable.vue'
import PlayerOptions from '@/components/PlayerOptions.vue'

export default {
  name: 'duel',
  components: {
    GameStatus,
    PlayerStatus,
    DuelRange,
    GameTable,
    PlayerOptions
  },
  data: function () {
    return {
    }
  },
  computed: {
    antagonist () {
      return this.$store.state.players.antagonist
    },
    protagonist () {
      return this.$store.state.players.protagonist
    } 
  },
  methods: {
  },
  mounted () {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

  .player-status-container {
    margin-bottom: 1rem;
  }

  .player-status-container-left {
    padding-right: 1rem;
  }

  .player-status-container-right {
    padding-left: 1rem;
  }

  .game-status-container {
    padding-right: 0;
    padding-left: 0;
    margin-bottom: 5px;
  }

  .duel-range-container {
    margin-bottom: 1rem;
  }

  .game-table-container {
    margin-bottom: 1rem;
  }

  .player-options-container {
    margin-bottom: 1rem;
  }

</style>
