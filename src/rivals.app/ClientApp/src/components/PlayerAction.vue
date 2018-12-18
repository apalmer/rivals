<template>
  <div class="player-action">
    <h1>Player Action</h1>
    <action-card></action-card>
    <action-card></action-card>
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
  h1 {
    color: antiquewhite;
  }
</style>
