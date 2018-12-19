<template>
  <div>
    <div class="container">

      <div class="row">
        <div class="col-md-5 player-status-container player-status-container-left">
          <div class="player-status"></div>
        </div>
        <div class="col-md-2 game-status-container">
          <div class="game-status"></div>
        </div>
        <div class="col-md-5 player-status-container player-status-container-right">
          <div class="player-status"></div>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-md-12 duel-range-container">
          <div class="duel-range"></div>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-md-12 game-table-container">
          <div class="game-table">
            <div class="player-hand-container container">
              <div class="player-hand">
                <div class="row">
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="player-hand-container container">
              <div class="player-hand">
                <div class="row">
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                  <div class="action-card-container col-sm-2">
                    <div class="action-card">
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-md-12 player-options-container">
          <div class="player-options">
            <div class="player-actions-container row">
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
              <div class="player-action-container col-md-2">
                <div class="player-action"></div>
              </div>
            </div>
            <div class="game-actions-container row">
              <div class="game-action-container col-md-12">
                <div class="game-action"></div>
              </div>
            </div>
          </div>
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
    methods: {
    },
    mounted() {
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

  .player-status {
    background-color: lightgrey;
    height: 5rem;
  }

  .game-status-container {
    padding-right: 0;
    padding-left: 0;
    margin-bottom: 5px;
  }

  .game-status {
    background-color: grey;
    height: 5rem;
  }

  .duel-range-container {
    margin-bottom: 1rem;
  }

  .duel-range {
    background-color: darkgrey;
    height: 5rem;
  }

  .game-table-container {
    margin-bottom: 1rem;
  }

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

  .player-hand {
    background-color: darkgrey;
    padding: 1rem;
  }

  .action-card-container {
    padding-right: 1rem;
  }

  .action-card {
    height: 10rem;
    background-color: white;
  }

  .player-options-container {
    margin-bottom: 1rem;
  }

  .player-options {
    background-color: darkgrey;
    padding: 1rem;
  }

  .player-actions-container {
    margin-top: -1rem;
  }

  .player-action-container {
    padding: 1rem;
  }

  .player-action {
    background-color: white;
    height: 10rem;
  }

  .game-actions-container {
    padding-left: 1rem;
    padding-right: 1rem;
  }

  .game-action-container {
  }

  .game-action {
    background-color: white;
    height: 5rem;
  }
</style>
