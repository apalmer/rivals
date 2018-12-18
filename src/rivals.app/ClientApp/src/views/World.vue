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
      users: []
    }
  },
  methods: {
    issueChallenge: function (user) {
      this.worldHub.invoke('IssueChallenge', user)
    },
    acceptChallenge: function (user) {
      this.worldHub.invoke('AcceptChallenge', user)
    },
    declineChallenge: function (user) {
      this.worldHub.invoke('DeclineChallenge', user)
    },
    challengeIssued: function (user) {
      this.$root.$emit('challenge-issued', user)
    },
    startDuel: function (duel) {
      this.$router.push({ name: 'duel', params: { duelId: duel.id } })
    },
    userConnected: function (user) {
      var found = false
      for (var i = 0; i < this.users.length; i++) {
        if (this.users[i].userName === user.userName) {
          this.users[i].connectionId = user.connectionId
          found = true
        }
      }
      if (!found) {
        this.users.push(user)
      }
    },
    userDisconnected: function (user) {
      for (var i = 0; i < this.users.length; i++) {
        if (this.users[i].connectionId === user.connectionId) {
          this.users.splice(i, 1)
        }
      }
    }
  },
  mounted () {
    var vueRef = this

    this.$root.$on('challenge-confirmed', this.issueChallenge)
    this.$root.$on('challenge-accepted', this.acceptChallenge)
    this.$root.$on('challenge-declined', this.declineChallenge)

    this.worldHub = new HubConnectionBuilder().withUrl('/WorldHub').build()

    this.worldHub.on('UserConnected', function (user) {
      vueRef.userConnected(user)
    })

    this.worldHub.on('UserDisconnected', function (user) {
      vueRef.userDisconnected(user)
    })

    this.worldHub.on('ChallengeIssued', function (user) {
      vueRef.challengeIssued(user)
    })

    this.worldHub.on('StartDuel', function (duel) {
      vueRef.startDuel(duel)
    })

    var connectionStarted = function () {
      vueRef.worldHub.stream('StreamUsers', 10, 500)
        .subscribe({
          next: (item) => {
            vueRef.userConnected(item)
          },
          complete: () => {
            console.log('Users stream completed.')
          },
          error: (err) => {
            console.error(err.toString())
          }
        })
    }

    this.worldHub.start()
      .then(function () {
        connectionStarted()
      })
      .catch(function (err) {
        return console.error(err.toString())
      })
  }
}
</script>
