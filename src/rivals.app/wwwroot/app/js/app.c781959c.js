(function(e){function t(t){for(var a,o,l=t[0],c=t[1],r=t[2],d=0,f=[];d<l.length;d++)o=l[d],s[o]&&f.push(s[o][0]),s[o]=0;for(a in c)Object.prototype.hasOwnProperty.call(c,a)&&(e[a]=c[a]);u&&u(t);while(f.length)f.shift()();return i.push.apply(i,r||[]),n()}function n(){for(var e,t=0;t<i.length;t++){for(var n=i[t],a=!0,l=1;l<n.length;l++){var c=n[l];0!==s[c]&&(a=!1)}a&&(i.splice(t--,1),e=o(o.s=n[0]))}return e}var a={},s={app:0},i=[];function o(t){if(a[t])return a[t].exports;var n=a[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,o),n.l=!0,n.exports}o.m=e,o.c=a,o.d=function(e,t,n){o.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},o.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},o.t=function(e,t){if(1&t&&(e=o(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(o.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var a in e)o.d(n,a,function(t){return e[t]}.bind(null,a));return n},o.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return o.d(t,"a",t),t},o.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},o.p="/app/";var l=window["webpackJsonp"]=window["webpackJsonp"]||[],c=l.push.bind(l);l.push=t,l=l.slice();for(var r=0;r<l.length;r++)t(l[r]);var u=c;i.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"034f":function(e,t,n){"use strict";var a=n("64a9"),s=n.n(a);s.a},"07e5":function(e,t,n){},"1a68":function(e,t,n){"use strict";var a=n("e824"),s=n.n(a);s.a},"1b33":function(e,t,n){},"1df0":function(e,t,n){},"3c6c":function(e,t,n){},"3f14":function(e,t,n){"use strict";var a=n("7903"),s=n.n(a);s.a},4271:function(e,t,n){"use strict";var a=n("07e5"),s=n.n(a);s.a},"56d7":function(e,t,n){"use strict";n.r(t);n("cadf"),n("551c"),n("097d");var a=n("2b0e"),s=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"app"}},[n("router-view")],1)},i=[],o=(n("034f"),n("2877")),l={},c=Object(o["a"])(l,s,i,!1,null,null,null);c.options.__file="App.vue";var r=c.exports,u=n("8c4f"),d=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"world"},[n("OnlineUserList",{attrs:{users:e.users}}),n("ChallengeConfirm"),n("ChallengeAccept")],1)},f=[],p=(n("6b54"),function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"online-user-list"},e._l(e.users,function(t){return n("OnlineUser",{key:t.userName,attrs:{user:t},on:{"challenge-user":e.challenge}})}),1)}),m=[],v=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"online-user",on:{click:function(t){e.clickUser(e.user)}}},[e._v(e._s(e.user.userName)+"\n")])},h=[],_={name:"OnlineUser",props:{user:Object},data:function(){return{}},methods:{clickUser:function(e){this.$root.$emit("challenge-user",e)}}},b=_,C=(n("9d27"),Object(o["a"])(b,v,h,!1,null,"98b9a3fe",null));C.options.__file="OnlineUser.vue";var g=C.exports,y={name:"OnlineUserList",components:{OnlineUser:g},props:{users:Array},methods:{challenge:function(e){alert("challenged in user list!! ".concat(e.userName))}}},$=y,w=(n("6ef1"),Object(o["a"])($,p,m,!1,null,"5e0fbf46",null));w.options.__file="OnlineUserList.vue";var O=w.exports,j=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"challenge-confirm"},[n("modal",{directives:[{name:"show",rawName:"v-show",value:e.isModalVisible,expression:"isModalVisible"}],on:{"close-modal":e.closeModal}},[n("template",{slot:"header"},[n("div")]),n("template",{slot:"body"},[e._v("\n      challenge "+e._s(e.challengedUser.userName)+" !?!\n    ")]),n("template",{slot:"footer"},[n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.cancelChallenge}},[e._v("Chicken")]),n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.confirmChallenge}},[e._v("Confirm")])])],2)],1)},M=[],x=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("transition",{attrs:{name:"modal"}},[n("div",{staticClass:"modal-mask"},[n("div",{staticClass:"modal-dialog-centered"},[n("div",{staticClass:"modal-dialog",attrs:{role:"document"}},[n("div",{staticClass:"modal-content"},[n("div",{staticClass:"modal-header"},[e._t("header",[n("h5",{staticClass:"modal-title"},[e._v("Modal title")]),n("button",{staticClass:"close",attrs:{type:"button","aria-label":"Close"},on:{click:e.close}},[n("span",{attrs:{"aria-hidden":"true"}},[e._v("×")])])])],2),n("div",{staticClass:"modal-body"},[e._t("body")],2),n("div",{staticClass:"modal-footer"},[e._t("footer",[n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.close}},[e._v("Cancel")])])],2)])])])])])},A=[],k={name:"Modal",methods:{close:function(){this.$emit("close-modal")}}},E=k,U=(n("4271"),Object(o["a"])(E,x,A,!1,null,"9b93343e",null));U.options.__file="Modal.vue";var P=U.exports,S={name:"ChallengeConfirm",components:{Modal:P},data:function(){return{challengedUser:Object,isModalVisible:!1}},methods:{challenge:function(e){this.challengedUser=e,this.showModal()},showModal:function(){this.isModalVisible=!0},closeModal:function(){this.isModalVisible=!1},cancelChallenge:function(){this.closeModal()},confirmChallenge:function(){this.$root.$emit("challenge-confirmed",this.challengedUser),this.closeModal()}},mounted:function(){this.$root.$on("challenge-user",this.challenge)}},H=S,G=Object(o["a"])(H,j,M,!1,null,null,null);G.options.__file="ChallengeConfirm.vue";var D=G.exports,I=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"challenge-accept"},[n("modal",{directives:[{name:"show",rawName:"v-show",value:e.isModalVisible,expression:"isModalVisible"}],on:{"close-modal":e.closeModal}},[n("template",{slot:"header"},[n("div")]),n("template",{slot:"body"},[e._v("\n      accept "+e._s(e.challengerUser.userName)+"'s challenge !?!\n    ")]),n("template",{slot:"footer"},[n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.declineChallenge}},[e._v("Chicken")]),n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.acceptChallenge}},[e._v("Confirm")])])],2)],1)},V=[],N={name:"ChallengeAccept",components:{Modal:P},data:function(){return{challengerUser:Object,isModalVisible:!1}},methods:{displayChallenge:function(e){this.challengerUser=e,this.showModal()},showModal:function(){this.isModalVisible=!0},closeModal:function(){this.isModalVisible=!1},declineChallenge:function(){this.$root.$emit("challenge-declined",this.challengerUser),this.closeModal()},acceptChallenge:function(){this.$root.$emit("challenge-accepted",this.challengerUser),this.closeModal()}},mounted:function(){this.$root.$on("challenge-issued",this.displayChallenge)}},T=N,R=Object(o["a"])(T,I,V,!1,null,null,null);R.options.__file="ChallengeAccept.vue";var L=R.exports,J=n("1a9a"),W={name:"world",components:{OnlineUserList:O,ChallengeConfirm:D,ChallengeAccept:L},data:function(){return{users:[]}},methods:{issueChallenge:function(e){this.worldHub.invoke("IssueChallenge",e)},acceptChallenge:function(e){this.worldHub.invoke("AcceptChallenge",e)},declineChallenge:function(e){this.worldHub.invoke("DeclineChallenge",e)},challengeIssued:function(e){this.$root.$emit("challenge-issued",e)},startDuel:function(e){this.$router.push({name:"duel",params:{duelId:e.id}})},userConnected:function(e){for(var t=!1,n=0;n<this.users.length;n++)this.users[n].userName===e.userName&&(this.users[n].connectionId=e.connectionId,t=!0);t||this.users.push(e)},userDisconnected:function(e){for(var t=0;t<this.users.length;t++)this.users[t].connectionId===e.connectionId&&this.users.splice(t,1)}},mounted:function(){var e=this;this.$root.$on("challenge-confirmed",this.issueChallenge),this.$root.$on("challenge-accepted",this.acceptChallenge),this.$root.$on("challenge-declined",this.declineChallenge),this.worldHub=(new J["a"]).withUrl("/WorldHub").build(),this.worldHub.on("UserConnected",function(t){e.userConnected(t)}),this.worldHub.on("UserDisconnected",function(t){e.userDisconnected(t)}),this.worldHub.on("ChallengeIssued",function(t){e.challengeIssued(t)}),this.worldHub.on("StartDuel",function(t){e.startDuel(t)});var t=function(){e.worldHub.stream("StreamUsers",10,500).subscribe({next:function(t){e.userConnected(t)},complete:function(){console.log("Users stream completed.")},error:function(e){console.error(e.toString())}})};this.worldHub.start().then(function(){t()}).catch(function(e){return console.error(e.toString())})}},B=W,q=Object(o["a"])(B,d,f,!1,null,null,null);q.options.__file="World.vue";var z=q.exports,F=(n("b6fe"),function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("span",[e._v("Spike")])}),K=[],Q={name:"spike",components:{},data:function(){return{}},methods:{},mounted:function(){}},X=Q,Y=(n("620a"),Object(o["a"])(X,F,K,!1,null,"663a09c4",null));Y.options.__file="Spike.vue";var Z=Y.exports;a["a"].use(u["a"]);var ee=new u["a"]({mode:"history",base:"/app/",routes:[{path:"/",name:"world",component:z},{path:"/duel/:duelId",name:"duel",component:function(){return Promise.resolve().then(n.bind(null,"b6fe"))}},{path:"/spike",name:"spike",component:Z}]}),te=n("2f62");a["a"].use(te["a"]);var ne=new te["a"].Store({state:{remainingRoundTime:15},mutations:{decrement:function(e){e.remainingRoundTime--}},actions:{}});n("4989"),n("ab8b");a["a"].config.productionTip=!1,new a["a"]({router:ee,store:ne,render:function(e){return e(r)}}).$mount("#app")},"5b0d":function(e,t,n){"use strict";var a=n("8ed1"),s=n.n(a);s.a},"620a":function(e,t,n){"use strict";var a=n("f2d3"),s=n.n(a);s.a},6499:function(e,t,n){"use strict";var a=n("1df0"),s=n.n(a);s.a},"64a9":function(e,t,n){},"699c":function(e,t,n){"use strict";var a=n("7726e"),s=n.n(a);s.a},"6da8":function(e,t,n){"use strict";var a=n("f3a0"),s=n.n(a);s.a},"6ef1":function(e,t,n){"use strict";var a=n("dd59"),s=n.n(a);s.a},"730c":function(e,t,n){},"7726e":function(e,t,n){},"78ef":function(e,t,n){},7903:function(e,t,n){},"79e7":function(e,t,n){},"84c5":function(e,t,n){},"8df4":function(e,t,n){"use strict";var a=n("730c"),s=n.n(a);s.a},"8ed1":function(e,t,n){},"90c9":function(e,t,n){"use strict";var a=n("84c5"),s=n.n(a);s.a},9513:function(e,t,n){"use strict";var a=n("78ef"),s=n.n(a);s.a},"9d27":function(e,t,n){"use strict";var a=n("79e7"),s=n.n(a);s.a},b6fe:function(e,t,n){"use strict";n.r(t);var a=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",[n("div",{staticClass:"container"},[n("div",{staticClass:"row"},[n("div",{staticClass:"col-md-5 player-status-container player-status-container-left"},[n("player-status")],1),n("div",{staticClass:"col-md-2 game-status-container"},[n("game-status")],1),n("div",{staticClass:"col-md-5 player-status-container player-status-container-right"},[n("player-status")],1)]),n("div",{staticClass:"row"},[n("div",{staticClass:"col-md-12 duel-range-container"},[n("duel-range")],1)]),n("div",{staticClass:"row"},[n("div",{staticClass:"col-md-12 game-table-container"},[n("game-table")],1)]),n("div",{staticClass:"row"},[n("div",{staticClass:"player-options-container col-md-12"},[n("player-options")],1)])])])},s=[],i=(n("cadf"),n("551c"),n("097d"),function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)}),o=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"game-status"},[n("span",[e._v("Game Status")])])}],l={name:"gameStatus",props:{}},c=l,r=(n("f882"),n("2877")),u=Object(r["a"])(c,i,o,!1,null,"4eae7b1e",null);u.options.__file="GameStatus.vue";var d=u.exports,f=function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)},p=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"player-status"},[n("span",[e._v("Player Status")])])}],m={name:"playerStatus",props:{}},v=m,h=(n("1a68"),Object(r["a"])(v,f,p,!1,null,"9dc1d048",null));h.options.__file="PlayerStatus.vue";var _=h.exports,b=function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)},C=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"duel-range"},[n("span",[e._v("Duel Range")])])}],g={name:"duelRange",props:{}},y=g,$=(n("dd22"),Object(r["a"])(y,b,C,!1,null,"57385078",null));$.options.__file="DuelRange.vue";var w=$.exports,O=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"game-table"},[n("span",[e._v("Game Table")]),n("div",{staticClass:"player-hand-container container"},[n("player-hand")],1),n("div",{staticClass:"player-hand-container container"},[n("player-hand")],1)])},j=[],M=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"player-hand"},[n("span",[e._v("Player Hand")]),n("div",{staticClass:"row"},[n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1),n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1),n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1),n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1),n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1),n("div",{staticClass:"action-card-container col-sm-2"},[n("action-card")],1)])])},x=[],A=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{class:[e.mini?"action-card-mini":"action-card"]},[n("span",[e._v("Action Card")])])},k=[],E={name:"actionCard",props:{mini:Boolean}},U=E,P=(n("8df4"),Object(r["a"])(U,A,k,!1,null,"486672ab",null));P.options.__file="ActionCard.vue";var S=P.exports,H={name:"playerHand",components:{ActionCard:S},props:{}},G=H,D=(n("e036"),Object(r["a"])(G,M,x,!1,null,"25d23dca",null));D.options.__file="PlayerHand.vue";var I=D.exports,V={name:"gameTable",components:{PlayerHand:I},props:{}},N=V,T=(n("3f14"),Object(r["a"])(N,O,j,!1,null,"782f8f58",null));T.options.__file="GameTable.vue";var R=T.exports,L=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"player-options"},[n("span",[e._v("Player Options")]),n("div",{staticClass:"player-actions-container row"},[n("player-actions")],1),n("div",{staticClass:"game-actions-container row"},[n("game-actions")],1)])},J=[],W=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"player-actions col-md-12"},[n("span",[e._v("Player Actions")]),n("div",{staticClass:"row"},[n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1),n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1),n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1),n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1),n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1),n("div",{staticClass:"player-action-container col-md-2"},[n("player-action")],1)])])},B=[],q=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"player-action"},[n("span",[e._v("Player Action")]),n("action-card",{attrs:{mini:!0}}),n("action-card",{attrs:{mini:!0}})],1)},z=[],F={name:"playerAction",components:{ActionCard:S},props:{}},K=F,Q=(n("90c9"),Object(r["a"])(K,q,z,!1,null,"2d942dc0",null));Q.options.__file="PlayerAction.vue";var X=Q.exports,Y={name:"playerActions",components:{PlayerAction:X},props:{}},Z=Y,ee=(n("6499"),Object(r["a"])(Z,W,B,!1,null,"06f99484",null));ee.options.__file="PlayerActions.vue";var te=ee.exports,ne=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"game-actions col-md-12"},[n("span",[e._v("Game Actions")]),n("div",{staticClass:"game-action-container"},[n("game-action")],1)])},ae=[],se=function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)},ie=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"game-action"},[n("span",[e._v("Game Action")])])}],oe={name:"gameAction",components:{},props:{}},le=oe,ce=(n("9513"),Object(r["a"])(le,se,ie,!1,null,"1fc940bc",null));ce.options.__file="GameAction.vue";var re=ce.exports,ue={name:"gameActions",components:{GameAction:re},props:{}},de=ue,fe=(n("699c"),Object(r["a"])(de,ne,ae,!1,null,"3aa8cfa4",null));fe.options.__file="GameActions.vue";var pe=fe.exports,me={name:"playerOptions",components:{PlayerActions:te,GameActions:pe},props:{}},ve=me,he=(n("6da8"),Object(r["a"])(ve,L,J,!1,null,"1a2b341d",null));he.options.__file="PlayerOptions.vue";var _e=he.exports,be={name:"duel",components:{GameStatus:d,PlayerStatus:_,DuelRange:w,GameTable:R,PlayerOptions:_e},data:function(){return{}},methods:{},mounted:function(){}},Ce=be,ge=(n("5b0d"),Object(r["a"])(Ce,a,s,!1,null,"bc54b83c",null));ge.options.__file="Duel.vue";t["default"]=ge.exports},b96c:function(e,t,n){},dd22:function(e,t,n){"use strict";var a=n("b96c"),s=n.n(a);s.a},dd59:function(e,t,n){},e036:function(e,t,n){"use strict";var a=n("3c6c"),s=n.n(a);s.a},e824:function(e,t,n){},f2d3:function(e,t,n){},f3a0:function(e,t,n){},f882:function(e,t,n){"use strict";var a=n("1b33"),s=n.n(a);s.a}});
//# sourceMappingURL=app.c781959c.js.map