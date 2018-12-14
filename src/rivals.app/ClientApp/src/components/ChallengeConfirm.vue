<template>
  <div class="challenge-confirm">
    <modal v-show="isModalVisible" @close-modal="closeModal">
      <template slot="header">
        <div></div>
      </template>
      <template slot="body">
        challenge {{challengedUser.userName}} !?!
      </template>
      <template slot="footer">
        <button @click="cancelChallenge">Chicken</button>
        <button @click="confirmChallenge">Confirm</button>
      </template>
    </modal>
  </div>
</template>

<script>
  // @ is an alias to /src
  import Modal from '@/components/Modal.vue'

  export default {
    name: 'ChallengeConfirm',
    components: {
      Modal
    },
    data: function () {
      return {
        challengedUser: Object,
        isModalVisible: false,
      }
    },
    methods: {
      challenge: function (user) {
        this.challengedUser = user;
        this.showModal();
      },
      showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      },
      cancelChallenge() {
        this.closeModal();
      },
      confirmChallenge() {
        this.$root.$emit('challenge-confirmed', this.challengedUser);
        this.closeModal();
      }
    },
    mounted() {
      this.$root.$on('challenge-user', this.challenge);
    }
  }
</script>
