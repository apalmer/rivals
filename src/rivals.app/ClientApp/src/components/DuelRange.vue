<template>
  <div class="duel-range">
    <span>Duel Range</span>
    <div>{{ rangeDescription }}</div>
  </div>
</template>

<script>
export default {
  name: 'duelRange',
  props: {
  },
  computed: {
    rangeDescription () {
      return this.$store.getters['players/rangeDescription']
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .duel-range {
    background-color: darkgrey;
    height: 5rem;
  }
</style>
