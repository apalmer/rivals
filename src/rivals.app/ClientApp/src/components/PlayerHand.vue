<template>
    <div class="player-hand">
      <span>Player Hand</span>
      <div class="row">
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
        <div class="action-card-container col-sm-2">
          <action-card></action-card>
        </div>
      </div>
    </div>
</template>

<script>
import ActionCard from '@/components/ActionCard.vue'

export default {
  name: 'playerHand',
  components: {
    ActionCard
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .player-hand {
    background-color: darkgrey;
    padding: 1rem;
  }

  .action-card-container {
    padding-right: 1rem;
  }
</style>
