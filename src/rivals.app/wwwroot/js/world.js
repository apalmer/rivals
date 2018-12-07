Vue.component('user-list', {
    props: ['users'],
    template: '<div class="user-list"><user-status v-for="user in users" v-bind:user="user" v-bind:key="user.id" ></user-status></div>'
});

Vue.component('user-status', {
    props: ['user'],
    template: '<div class="user-status">{{user.connectionId}}</div>'
});

var world = new Vue({
    el: '#world',
    data: {
        users: [
            { connectionId: 'system' }
        ]
    },
    methods: {
        userConnected: function (user) {
            this.users.push({ connectionId: user});
        },
        userDisconnected: function (user) {
            for (var i = 0; i < this.users.length; i++) {
                if (this.users[i].connectionId === user) {
                    this.users.splice(i, 1);
                }
            }
        }
    }
});

var worldConnection = new signalR.HubConnectionBuilder().withUrl("/worldHub").build();

worldConnection.on("UserConnected", function (user) {
    world.userConnected(user);
});

worldConnection.on("UserDisconnected", function (user) {
    world.userDisconnected(user);
});

worldConnection.start().catch(function (err) {
    return console.error(err.toString());
});