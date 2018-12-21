<template>
  <div class="player-status">
    <span>Player Status</span>
    <div>{{ player.playerName }}</div>
    <div class="max-health">
      <div class="current-health" v-bind:style="{width: playerHealthPercent }">{{ player.health }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'playerStatus',
    props: {
      mode: String,
      player: Object
    },
    data: function () {
      return {}
    },
    computed: {
      playerHealthPercent () {
        return this.player.health + '%'
      }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .protagonist-layout{
    float:left;
  }
  .antagonist-layout {
    float: right;
  }
  .player-status {
    background-color: lightgrey;
    height: 5rem;
  }
  .max-health {
    background-color : red;
    width: 100%
  }
  .current-health {
    background-color : gold;
  }
</style>
