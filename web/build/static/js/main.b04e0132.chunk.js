(window.webpackJsonp=window.webpackJsonp||[]).push([[0],{15:function(e,n,t){e.exports=t(28)},28:function(e,n,t){"use strict";t.r(n);var r=t(0),a=t.n(r),c=t(5),o=t(4),i=t.n(o),u=t(6),l=t(3),s=t(1),f=t(2),d="".concat("http://localhost:4000","/api"),m=t(14),p=function(e,n,t,r){var a={method:n,headers:{Accept:"application/json, text/plain, */*","Content-Type":"application/json"}};return"get"!==n.toLowerCase()&&t&&(a=Object(m.a)({},a,{body:JSON.stringify(t)})),r(e,a).then(function(e){return e.json().then(function(n){return e.ok?n:Promise.reject(n)})})},b={EmailIsNotSpecified:"Email is not specified",EmailLacksAtCharacter:"Email is invalid",PasswordIsTooShort:"Password should have 8 characters minimum",PasswordLacksUpperCaseCharacter:"Password should have at least 1 uppercase character",PasswordLacksLowerCaseCharacter:"Password should have at least 1 lowercase character",PasswordLacksDigitCharacter:"Password should have at least 1 digit character",PasswordLacksSpecialCharacter:"Password should have at least 1 special character",OperationCompletedSuccessfully:"Operation completed successfully"},h=function(e){var n=e.message;return b[n]||"An error occured"};function v(){var e=Object(s.a)(["\n    @media (min-width: ","em) {\n      ","\n    }\n  "]);return v=function(){return e},e}var g={largeDesktop:992,desktop:768,tablet:576},w=Object.keys(g).reduce(function(e,n){return e["".concat(n,"Up")]=function(){return Object(f.b)(v(),g[n]/16,f.b.apply(void 0,arguments))},e},{});function j(){var e=Object(s.a)(['\n  html {\n    font-size: 0.625em;\n    font-family: "Roboto", "Helvetica", "Arial", sans-serif;\n  }\n  body {\n    background-color: #f5f5f5;\n  }\n  #root {\n    max-width: 76rem;\n    margin: auto;\n  }\n']);return j=function(){return e},e}var O=Object(f.a)(j()),E=function(e){var n=e.heading;return a.a.createElement("header",null,a.a.createElement("h1",null,n))};function k(){var e=Object(s.a)(["\n    text-align: center;\n"]);return k=function(){return e},e}var x=f.c.p(k()),y=function(e){var n=e.text;return a.a.createElement("footer",null,a.a.createElement(x,null,n))};function C(){var e=Object(s.a)(["\n  display: flex;\n  flex-direction: column;\n\n  & input{\n    height: 3.6rem;\n    border: solid 0.1rem #a6a6a6;\n    font-size: 0.5rem;\n  }\n"]);return C=function(){return e},e}var P=f.c.div(C()),S=function(e){var n=e.onChange,t=e.label,r=e.type,c=e.id,o=e.value;return a.a.createElement(P,null,a.a.createElement("label",{htmlFor:c},t),a.a.createElement("input",{"aria-label":"form-input","data-testid":t,type:r,id:c,value:o,onChange:function(e){return n(e.currentTarget.value)}}))};function L(){var e=Object(s.a)(["\n  background-color: #1e808f;\n  border-radius: 0.3rem;\n  color: #ffffff;\n  padding: 1em;\n  min-width: 10em;\n\n  &:disabled{\n    background-color: #b2b2b2;\n  }\n"]);return L=function(){return e},e}var F=f.c.button(L());function A(){var e=Object(s.a)(["\n    align-self: flex-start;\n    flex-grow: 0;\n  "]);return A=function(){return e},e}function N(){var e=Object(s.a)([" \n  padding: 1rem;\n  box-shadow: 0 0.1rem 0.2rem 0 #00000080;\n  background-color: #ffffff;\n  align-self: stretch;\n  min-width: 25rem;\n\n  & > *:not(:last-child){\n    margin-bottom: 1rem;\n  }\n\n  ","\n"]);return N=function(){return e},e}function U(){var e=Object(s.a)([" \n  padding: 1rem;\n  box-shadow: 0 0.1rem 0.2rem 0 #00000080;\n  background-color: #f5f5f5;\n  margin-top: 1rem;\n  \n"]);return U=function(){return e},e}var z=f.c.div(U()),D=f.c.form(N(),w.tabletUp(A())),I=function(e){var n=e.heading,t=e.saveForm,c=Object(r.useState)([]),o=Object(l.a)(c,2),i=o[0],u=o[1],s=Object(r.useState)(""),f=Object(l.a)(s,2),d=f[0],m=f[1],p=Object(r.useState)(""),b=Object(l.a)(p,2),h=b[0],v=b[1],g=function(){return!(!d||!h)};return a.a.createElement(D,null,a.a.createElement("h2",null,n),i.map(function(e,n){return a.a.createElement(z,{key:n},e)}),a.a.createElement(S,{label:"Email",type:"text",id:"email",value:d,onChange:m}),a.a.createElement(S,{label:"Password",type:"password",id:"password",value:h,onChange:v}),a.a.createElement(F,{"data-testid":"Save",disabled:!g(),onClick:function(){u([]),g()&&t({email:d,password:h},u),m(""),v("")},type:"button"},"Save"))};function J(){var e=Object(s.a)(["\n  margin: 0;\n  padding: 0;\n  list-style-type: none;\n  & > *:not(:last-child){\n    margin-bottom: 1rem;\n  }\n"]);return J=function(){return e},e}function R(){var e=Object(s.a)(["\n  padding: 1rem;\n  box-shadow: 0 0.1rem 0.2rem 0 #00000080;\n  background-color: #ffffff;\n"]);return R=function(){return e},e}function T(){var e=Object(s.a)(["\n  font-size: 2rem;\n  color: #002d64;\n"]);return T=function(){return e},e}var W=f.c.h3(T()),B=f.c.li(R()),H=f.c.ul(J()),M=function(e){var n=e.users;return a.a.createElement(H,null,n.map(function(e,n){var t=e.email,r=e.password;return a.a.createElement(B,{"data-testid":"user-item",key:n},a.a.createElement(W,null,t),a.a.createElement("p",null,r))}))};M.defaultProps={users:[]};var Y=M;function q(){var e=Object(s.a)(["\n  flex-grow: 1;\n\n  & > *:not(:first-child){\n    margin-top: 1rem;\n  }\n"]);return q=function(){return e},e}function G(){var e=Object(s.a)(["\n    flex-direction: row;\n\n    & > *:not(:last-child){\n      margin-right: 2rem;\n    }\n  "]);return G=function(){return e},e}function K(){var e=Object(s.a)(["\n  display: flex;\n  flex-direction: column;\n  justify-content: space-between;\n  align-items: stretch;\n\n  & > *:not(:last-child){\n    margin-bottom: 2rem;\n  }\n\n  ","\n"]);return K=function(){return e},e}var Q=f.c.div(K(),w.tabletUp(G())),V=f.c.div(q()),X=function(){var e=Object(r.useState)([]),n=Object(l.a)(e,2),t=n[0],c=n[1],o=Object(r.useState)(1),s=Object(l.a)(o,2),f=s[0],m=s[1],b=Object(r.useState)(!1),v=Object(l.a)(b,2),g=v[0],w=v[1],j=Object(r.useState)(!1),k=Object(l.a)(j,2),x=k[0],C=k[1],P=function(){var e=Object(u.a)(i.a.mark(function e(){var n,t,r,a,o,u,l,s=arguments;return i.a.wrap(function(e){for(;;)switch(e.prev=e.next){case 0:return n=s.length>0&&void 0!==s[0]?s[0]:1,e.next=3,p("".concat(d,"/users?page=").concat(n),"get",{},fetch);case 3:t=e.sent,r=t.payload,a=r.users,o=r.page,u=r.hasPreviousPage,l=r.hasNextPage,c(a),m(o),C(l),w(u);case 13:case"end":return e.stop()}},e,this)}));return function(){return e.apply(this,arguments)}}(),S=function(){var e=Object(u.a)(i.a.mark(function e(n){var t,r,a,c,o=arguments;return i.a.wrap(function(e){for(;;)switch(e.prev=e.next){case 0:if(t=n.email,r=n.password,a=o.length>1&&void 0!==o[1]?o[1]:function(){},t&&r){e.next=4;break}return e.abrupt("return");case 4:return e.prev=4,e.next=7,p("".concat(d,"/users"),"post",{email:t,password:r},fetch);case 7:return e.next=9,P();case 9:e.next=15;break;case 11:e.prev=11,e.t0=e.catch(4),c=e.t0.responseMessages,a(c.map(h));case 15:case"end":return e.stop()}},e,this,[[4,11]])}));return function(n){return e.apply(this,arguments)}}();return Object(r.useEffect)(function(){P()},[]),a.a.createElement(r.Fragment,null,a.a.createElement(O,null),a.a.createElement(E,{heading:"WorldRemit"}),a.a.createElement(Q,null,a.a.createElement(I,{heading:"Enter your details here",saveForm:S}),a.a.createElement(V,null,a.a.createElement(Y,{users:t}),a.a.createElement(F,{onClick:function(){return P(f-1)},disabled:!g},"Previous"),a.a.createElement(F,{onClick:function(){return P(f+1)},disabled:!x},"Next"))),a.a.createElement(y,{text:"WorldRemit tech task ".concat((new Date).getFullYear())}))};Object(c.render)(a.a.createElement(X,null),document.getElementById("root"))}},[[15,1,2]]]);
//# sourceMappingURL=main.b04e0132.chunk.js.map