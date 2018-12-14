<template>
  <div class="challenge-accept">
    <modal v-show="isModalVisible" @close-modal="closeModal">
      <template slot="header">
        <div></div>
      </template>
      <template slot="body">
        accept {{challengerUser.userName}}'s challenge !?!
      </template>
      <template slot="footer">
        <button @click="declineChallenge">Chicken</button>
        <button @click="acceptChallenge">Confirm</button>
      </template>
    </modal>
  </div>
</template>

<script>
// @ is an alias to /src
import Modal from '@/components/Modal.vue'

export default {
  name: 'ChallengeAccept',
  components: {
    Modal
  },
  data: function () {
    return {
      challengerUser: Object,
      isModalVisible: false
    }
  },
  methods: {
    displayChallenge: function (user) {
      this.challengerUser = user
      this.showModal()
    },
    showModal () {
      this.isModalVisible = true
    },
    closeModal () {
      this.isModalVisible = false
    },
    declineChallenge () {
      this.closeModal()
    },
    acceptChallenge () {
      this.$root.$emit('challenge-accepted', this.challengerUser)
      this.closeModal()
    }
  },
  mounted () {
    this.$root.$on('challenge-issued', this.displayChallenge)
  }
}
</script>
