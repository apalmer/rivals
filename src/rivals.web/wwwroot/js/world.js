Vue.component('user-list', {
    props: ['users'],
    template: '<div class="user-list"><user-status v-for="user in users" v-bind:user="user" v-bind:key="user.id" ></user-status></div>'
});

Vue.component('user-status', {
    props: ['user'],
    template: '<div class="user-status" :data-connection-id="user.connectionId">{{user.userName}}</div>'
});

var world = new Vue({
    el: '#world',
    data: {
        sessionId: null,
        users: [
        ]
    },
    beforeMount: function () {
        this.sessionId = this.$el.attributes['data-session-id'].value;
    },
    methods: {
        userConnected: function (userName, connectionId) {
            this.users.push({ userName: userName, connectionId: connectionId});
        },
        userDisconnected: function (userName, connectionId) {
            for (var i = 0; i < this.users.length; i++) {
                if (this.users[i].connectionId === connectionId) {
                    this.users.splice(i, 1);
                }
            }
        }
    }
});

var worldConnection = new signalR.HubConnectionBuilder().withUrl("/worldHub").build();

worldConnection.on("UserConnected", function (userName, connectionId) {
    world.userConnected(userName, connectionId);
});

worldConnection.on("UserDisconnected", function (userName, connectionId) {
    world.userDisconnected(userName, connectionId);
});

worldConnection.start().catch(function (err) {
    return console.error(err.toString());
});