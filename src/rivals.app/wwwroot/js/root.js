
Vue.component('chat-log', {
    props: ['chatHistory'],
    template: '<div class="chat-log"><chat-item v-for="line in chatHistory" v-bind:chat-entry="line" v-bind:key="line.id" ></chat-item ></div>'
});

Vue.component('chat-item', {
    props: ['chatEntry'],
    template: '<div class="chat-entry">{{chatEntry.user}}:{{ chatEntry.text }}</div>'
});


Vue.component('chat-input', {
    data: function () {
        return {
            chatMessage: ''
        };
    },
    methods: {
        sendMessage: function () {
            root.relayMessage('system', this.chatMessage);
        }
    },
    template: '<div class="chat-input"><input type="text"  v-model="chatMessage"></input><input type="button" value="Enter" v-on:click="sendMessage"></input></div>'
});

var root = new Vue({
    el: '#root',
    data: {
        chat: [
            { user: 'system', text: 'This is the first Message' }
        ]
    },
    methods: {
        recieveMessage: function (user, message) {
            this.chat.push({ user: user, text: message });
        },
        relayMessage: function (user, message) {
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
});

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message) {
    root.recieveMessage(user, message);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});