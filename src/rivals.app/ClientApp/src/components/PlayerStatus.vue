<template>
  <div class="player-status">
    <span>Player Status</span>
    <div class="max-health">
      <div v-bind:class="[reverseLayout ? 'reverse-layout' : 'normal-layout',' current-health']" v-bind:style="{width: playerHealthPercent }"></div>
    </div>
    <div v-bind:class="[reverseLayout ? 'reverse-nameplate-layout' : 'nameplate-layout', 'nameplate']">{{ player.playerName }}</div>
  </div>
</template>

<script>
export default {
  name: 'playerStatus',
    props: {
      reverseLayout: Boolean,
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
  .reverse-layout{
    float: right;
  }
  .normal-layout {
    float: left;
  }
  .reverse-nameplate-layout {
    float: left;
  }
  .nameplate-layout {
    float: right;
  }
  .name-plate {

  }
  .player-status {
    background-color: lightgrey;
    height: 5rem;
  }
  .max-health {
    background-color : red;
    width: 100%;
    height: 2rem;
  }
  .current-health {
    background-color : gold;
    height: 2rem;
  }
</style>
