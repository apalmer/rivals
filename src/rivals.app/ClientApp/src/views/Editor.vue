<template>
  <div>
    <span>Editor</span>
    <card-editor></card-editor>
    <action-editor></action-editor>
    <character-editor></character-editor>
  </div>
</template>

<script>
import ActionEditor from '@/components/Editor/ActionEditor.vue'
import CardEditor from '@/components/Editor/CardEditor.vue'
import CharacterEditor from '@/components/Editor/CharacterEditor.vue'

export default {
  name: 'editor',
  components: {
    ActionEditor,
    CardEditor,
    CharacterEditor
  },
  data: function () {
    return {
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

</style>
