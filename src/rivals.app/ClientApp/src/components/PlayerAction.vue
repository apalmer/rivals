<template>
  <div class="player-action">
    <span>Player Action</span>
    <action-card v-bind:mini="true"></action-card>
    <action-card v-bind:mini="true"></action-card>
  </div>
</template>

<script>
import ActionCard from '@/components/ActionCard.vue'

export default {
  name: 'playerAction',
  components: {
    ActionCard
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .player-action {
    background-color: white;
  }
</style>
