<template>
  <div class="world">
    <OnlineUserList v-bind:users="users"></OnlineUserList>
    <ChallengeConfirm></ChallengeConfirm>
    <ChallengeAccept></ChallengeAccept>
  </div>
</template>

<script>
// @ is an alias to /src
import OnlineUserList from '@/components/OnlineUserList.vue'
import ChallengeConfirm from '@/components/ChallengeConfirm.vue'
import ChallengeAccept from '@/components/ChallengeAccept.vue'

import { HubConnectionBuilder } from '@aspnet/signalr'

export default {
  name: 'world',
  components: {
    OnlineUserList,
    ChallengeConfirm,
    ChallengeAccept
  },
  data: function () {
    return {
      users: [
        { userName: 'Someone', connectionId: '12345' },
        { userName: 'SomeoneElse', connectionId: '23456' },
        { userName: 'SomeOther', connectionId: '34567' }
      ]
    }
  },
  methods: {
    submitChallenge: function (user) {
      alert(`submitting challenge to ${user.userName}`)
    },
    acceptChallenge: function (user) {
      alert(`accepting challenge from ${user.userName}`)
    }
  },
  mounted () {
    this.$root.$on('challenge-confirmed', this.submitChallenge)
    this.$root.$on('challenge-accepted', this.acceptChallenge)

    this.worldHub = new HubConnectionBuilder().withUrl('/ChatHub').build()
    this.worldHub.start()
  }
}
</script>
