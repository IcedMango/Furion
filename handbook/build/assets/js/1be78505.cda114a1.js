"use strict";(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[9514,4972],{4326:(e,t,n)=>{n.r(t),n.d(t,{default:()=>Se});var a=n(7294),l=n(6010),o=n(1944),i=n(5281),r=n(3320),c=n(3438),s=n(4477),d=n(1116),m=n(179),u=n(5999),p=n(2466),b=n(5936);const h={backToTopButton:"backToTopButton_sjWU",backToTopButtonShow:"backToTopButtonShow_xfvO"};function g(){const{shown:e,scrollToTop:t}=function(e){let{threshold:t}=e;const[n,l]=(0,a.useState)(!1),o=(0,a.useRef)(!1),{startScroll:i,cancelScroll:r}=(0,p.Ct)();return(0,p.RF)(((e,n)=>{let{scrollY:a}=e;const i=n?.scrollY;i&&(o.current?o.current=!1:a>=i?(r(),l(!1)):a<t?l(!1):a+window.innerHeight<document.documentElement.scrollHeight&&l(!0))})),(0,b.S)((e=>{e.location.hash&&(o.current=!0,l(!1))})),{shown:n,scrollToTop:()=>i(0)}}({threshold:300});return a.createElement("button",{"aria-label":(0,u.I)({id:"theme.BackToTopButton.buttonAriaLabel",message:"Scroll back to top",description:"The ARIA label for the back to top button"}),className:(0,l.Z)("clean-btn",i.k.common.backToTopButton,h.backToTopButton,e&&h.backToTopButtonShow),type:"button",onClick:t})}var f=n(6550),E=n(7524),k=n(6668),y=n(4996),v=n(7462);function S(e){return a.createElement("svg",(0,v.Z)({width:"20",height:"20","aria-hidden":"true"},e),a.createElement("g",{fill:"#7a7a7a"},a.createElement("path",{d:"M9.992 10.023c0 .2-.062.399-.172.547l-4.996 7.492a.982.982 0 01-.828.454H1c-.55 0-1-.453-1-1 0-.2.059-.403.168-.551l4.629-6.942L.168 3.078A.939.939 0 010 2.528c0-.548.45-.997 1-.997h2.996c.352 0 .649.18.828.45L9.82 9.472c.11.148.172.347.172.55zm0 0"}),a.createElement("path",{d:"M19.98 10.023c0 .2-.058.399-.168.547l-4.996 7.492a.987.987 0 01-.828.454h-3c-.547 0-.996-.453-.996-1 0-.2.059-.403.168-.551l4.625-6.942-4.625-6.945a.939.939 0 01-.168-.55 1 1 0 01.996-.997h3c.348 0 .649.18.828.45l4.996 7.492c.11.148.168.347.168.55zm0 0"})))}const _={collapseSidebarButton:"collapseSidebarButton_PEFL",collapseSidebarButtonIcon:"collapseSidebarButtonIcon_kv0_"};function x(e){let{onClick:t}=e;return a.createElement("button",{type:"button",title:(0,u.I)({id:"theme.docs.sidebar.collapseButtonTitle",message:"Collapse sidebar",description:"The title attribute for collapse button of doc sidebar"}),"aria-label":(0,u.I)({id:"theme.docs.sidebar.collapseButtonAriaLabel",message:"Collapse sidebar",description:"The title attribute for collapse button of doc sidebar"}),className:(0,l.Z)("button button--secondary button--outline",_.collapseSidebarButton),onClick:t},a.createElement(S,{className:_.collapseSidebarButtonIcon}))}var C=n(9689),I=n(902);const w=Symbol("EmptyContext"),N=a.createContext(w);function T(e){let{children:t}=e;const[n,l]=(0,a.useState)(null),o=(0,a.useMemo)((()=>({expandedItem:n,setExpandedItem:l})),[n]);return a.createElement(N.Provider,{value:o},t)}var Z=n(6043),B=n(8596),L=n(9960),z=n(2389);function A(e){let{categoryLabel:t,onClick:n}=e;return a.createElement("button",{"aria-label":(0,u.I)({id:"theme.DocSidebarItem.toggleCollapsedCategoryAriaLabel",message:"Toggle the collapsible sidebar category '{label}'",description:"The ARIA label to toggle the collapsible sidebar category"},{label:t}),type:"button",className:"clean-btn menu__caret",onClick:n})}function H(e){let{item:t,onItemClick:n,activePath:o,level:r,index:s,...d}=e;const{items:m,label:u,collapsible:p,className:b,href:h}=t,{docs:{sidebar:{autoCollapseCategories:g}}}=(0,k.L)(),f=function(e){const t=(0,z.Z)();return(0,a.useMemo)((()=>e.href?e.href:!t&&e.collapsible?(0,c.Wl)(e):void 0),[e,t])}(t),E=(0,c._F)(t,o),y=(0,B.Mg)(h,o),{collapsed:S,setCollapsed:_}=(0,Z.u)({initialState:()=>!!p&&(!E&&t.collapsed)}),{expandedItem:x,setExpandedItem:C}=function(){const e=(0,a.useContext)(N);if(e===w)throw new I.i6("DocSidebarItemsExpandedStateProvider");return e}(),T=function(e){void 0===e&&(e=!S),C(e?null:s),_(e)};return function(e){let{isActive:t,collapsed:n,updateCollapsed:l}=e;const o=(0,I.D9)(t);(0,a.useEffect)((()=>{t&&!o&&n&&l(!1)}),[t,o,n,l])}({isActive:E,collapsed:S,updateCollapsed:T}),(0,a.useEffect)((()=>{p&&null!=x&&x!==s&&g&&_(!0)}),[p,x,s,_,g]),a.createElement("li",{className:(0,l.Z)(i.k.docs.docSidebarItemCategory,i.k.docs.docSidebarItemCategoryLevel(r),"menu__list-item",{"menu__list-item--collapsed":S},b)},a.createElement("div",{className:(0,l.Z)("menu__list-item-collapsible",{"menu__list-item-collapsible--active":y})},a.createElement(L.Z,(0,v.Z)({className:(0,l.Z)("menu__link",{"menu__link--sublist":p,"menu__link--sublist-caret":!h&&p,"menu__link--active":E}),onClick:p?e=>{n?.(t),h?T(!1):(e.preventDefault(),T())}:()=>{n?.(t)},"aria-current":y?"page":void 0,"aria-expanded":p?!S:void 0,href:p?f??"#":f},d),u),h&&p&&a.createElement(A,{categoryLabel:u,onClick:e=>{e.preventDefault(),T()}})),a.createElement(Z.z,{lazy:!0,as:"ul",className:"menu__list",collapsed:S},a.createElement(V,{items:m,tabIndex:S?-1:0,onItemClick:n,activePath:o,level:r+1})))}var W=n(3919),F=n(9471);const M={menuExternalLink:"menuExternalLink_NmtK"};function P(e){let{item:t,onItemClick:n,activePath:o,level:r,index:s,...d}=e;const{href:m,label:u,className:p,autoAddBaseUrl:b}=t,h=(0,c._F)(t,o),g=(0,W.Z)(m);return a.createElement("li",{className:(0,l.Z)(i.k.docs.docSidebarItemLink,i.k.docs.docSidebarItemLinkLevel(r),"menu__list-item",p),key:u},a.createElement(L.Z,(0,v.Z)({className:(0,l.Z)("menu__link",!g&&M.menuExternalLink,{"menu__link--active":h}),autoAddBaseUrl:b,"aria-current":h?"page":void 0,to:m},g&&{onClick:n?()=>n(t):void 0},d),u,!g&&a.createElement(F.Z,null)))}const R={menuHtmlItem:"menuHtmlItem_M9Kj"};function D(e){let{item:t,level:n,index:o}=e;const{value:r,defaultStyle:c,className:s}=t;return a.createElement("li",{className:(0,l.Z)(i.k.docs.docSidebarItemLink,i.k.docs.docSidebarItemLinkLevel(n),c&&[R.menuHtmlItem,"menu__list-item"],s),key:o,dangerouslySetInnerHTML:{__html:r}})}function j(e){let{item:t,...n}=e;switch(t.type){case"category":return a.createElement(H,(0,v.Z)({item:t},n));case"html":return a.createElement(D,(0,v.Z)({item:t},n));default:return a.createElement(P,(0,v.Z)({item:t},n))}}function U(e){let{items:t,...n}=e;return a.createElement(T,null,t.map(((e,t)=>a.createElement(j,(0,v.Z)({key:t,item:e,index:t},n)))))}const V=(0,a.memo)(U),K={menu:"menu_SIkG",menuWithAnnouncementBar:"menuWithAnnouncementBar_GW3s"};function Y(e){let{path:t,sidebar:n,className:o}=e;const r=function(){const{isActive:e}=(0,C.nT)(),[t,n]=(0,a.useState)(e);return(0,p.RF)((t=>{let{scrollY:a}=t;e&&n(0===a)}),[e]),e&&t}();return a.createElement("nav",{"aria-label":(0,u.I)({id:"theme.docs.sidebar.navAriaLabel",message:"Docs sidebar",description:"The ARIA label for the sidebar navigation"}),className:(0,l.Z)("menu thin-scrollbar",K.menu,r&&K.menuWithAnnouncementBar,o)},a.createElement("ul",{className:(0,l.Z)(i.k.docs.docSidebarMenu,"menu__list")},a.createElement(V,{items:n,activePath:t,level:1})))}var q=n(1327);const G=[{title:"CRMEB \u4e13\u6ce8\u5f00\u6e90\u7535\u5546\u7cfb\u7edf\u7814\u53d1",picture:"img/crmeb.jpg",url:"http://github.crmeb.net/u/furion",top:!1},{title:"\u6d41\u4e4b\u4e91 - \u4fe1\u606f\u5316\u3001\u6570\u5b57\u5316\u670d\u52a1\u63d0\u4f9b\u5546",picture:"img/tpflow.png",url:"https://www.gadmin8.com?from=furion",top:!1},{title:"CoreShop \u79fb\u52a8\u7aef/\u5c0f\u7a0b\u5e8f\u5546\u57ce\u7cfb\u7edf",picture:"img/coreshop.gif",url:"https://www.coreshop.cn?from=furion",top:!1},{title:"Layui-Vue \u5f00\u6e90\u524d\u7aef UI \u6846\u67b6",picture:"img/layui.png",url:"http://www.layui-vue.com?from=furion",top:!1},{title:"\u5de5\u4f5c\u670d\u5b9a\u5236T\u6064  \u4e00\u4ef6\u8d77\u8ba2\u6765\u56fe\u5b9a\u505a",picture:"img/weishen.jpg",url:"https://eshan.tmall.com?from=furion",top:!1},{title:"DIY \u53ef\u89c6\u5316 UniApp \u4ee3\u7801\u751f\u6210\u5668",picture:"img/lk.jpg",url:"https://www.diygw.com?from=furion",top:!1},{title:"MaxKey - \u4e1a\u754c\u9886\u5148\u7684\u5355\u70b9\u767b\u5f55\u4ea7\u54c1",picture:"img/maxkey.png",url:"https://gitee.com/dromara/MaxKey?from=furion",top:!0}],O={sidebar:"sidebar_mhZE",sidebarWithHideableNavbar:"sidebarWithHideableNavbar__6UL",sidebarHidden:"sidebarHidden__LRd",sidebarLogo:"sidebarLogo_F_0z"};function X(e){let{path:t,sidebar:n,onCollapse:o,isHidden:i}=e;const{navbar:{hideOnScroll:r},docs:{sidebar:{hideable:c}}}=(0,k.L)(),[s,d]=(0,a.useState)(!0);return a.createElement("div",{className:(0,l.Z)(O.sidebar,r&&O.sidebarWithHideableNavbar,i&&O.sidebarHidden)},r&&a.createElement(q.Z,{tabIndex:-1,className:O.sidebarLogo}),s&&a.createElement(a.Fragment,null,a.createElement(J,null),a.createElement("span",{style:{margin:"0 auto",display:"inline-block",position:"relative",top:5,marginTop:-28,cursor:"pointer",borderRadius:"50%",width:28,height:28,minWidth:28,minHeight:28,display:"flex",alignItems:"center",justifyContent:"center",boxSizing:"border-box",userSelect:"none",fontSize:12,backgroundColor:"#3fbbfe",color:"#fff",fontWeight:"bold"},onClick:()=>d((e=>!e))},"\u6536")),a.createElement(Y,{path:t,sidebar:n}),c&&a.createElement(x,{onClick:o}))}function J(){const e=G.findIndex((e=>e.top)),t=G.find((e=>e.top));return a.createElement("div",{style:{margin:"0.5em",display:"block",borderBottom:"1px solid #dedede",paddingBottom:"0.2em",clear:"both"}},a.createElement(Q,{title:t.title,url:t.url,picture:t.picture,top:!0,last:!1}),G.filter(((t,n)=>n!==e)).map(((e,t)=>{let{picture:n,url:l,title:o}=e;return a.createElement($,{key:l,title:o,url:l,picture:n,i:t})})),a.createElement("div",{style:{display:"flex",justifyContent:"space-between",alignItems:"center",padding:"5px 0"}},a.createElement("span",{style:{fontSize:12,color:"#ccc"}},"\u5408\u4f5c\u5fae\u4fe1\u53f7\uff1aibaiqian"),a.createElement("a",{href:"/docs/donate",style:{color:"#723cff",fontSize:13,fontWeight:"bold"},title:"monksoul@outlook.com"},"\u6210\u4e3a\u8d5e\u52a9\u5546")))}function Q(e){let{picture:t,url:n,last:l,title:o,top:i}=e;return a.createElement("a",{href:n,target:"_blank",title:o,style:{display:"block",marginBottom:l?null:"0.5em",position:"relative",alignItems:"center",boxSizing:"border-box",border:i?"2px solid rgb(255, 176, 46)":void 0}},a.createElement("img",{src:(0,y.Z)(t),style:{display:"block",width:"100%"},loading:"lazy"}),i&&a.createElement("span",{style:{position:"absolute",zIndex:10,top:-16,right:-8}},"\ud83d\udc51"),a.createElement("span",{style:{position:"absolute",display:"block",right:0,bottom:0,zIndex:10,fontSize:12,backgroundColor:"rgba(0,0,0,0.8)",padding:"0 5px"}}))}function $(e){let{picture:t,url:n,title:l,i:o}=e;return a.createElement("a",{href:n,target:"_blank",title:l,style:{display:"inline-block",position:"relative",width:"48.5%",marginRight:o%2!=0?0:8,position:"relative",boxSizing:"border-box"}},a.createElement("img",{src:(0,y.Z)(t),style:{display:"block",width:"100%"},loading:"lazy"}))}const ee=a.memo(X);var te=n(3102),ne=n(3163);const ae=e=>{let{sidebar:t,path:n}=e;const o=(0,ne.e)(),[r,c]=(0,a.useState)(!0);return a.createElement(a.Fragment,null,r&&a.createElement(a.Fragment,null,a.createElement(oe,null),a.createElement("span",{style:{margin:"0 auto",display:"inline-block",position:"relative",top:5,marginTop:-28,cursor:"pointer",borderRadius:"50%",width:28,height:28,minWidth:28,minHeight:28,display:"flex",alignItems:"center",justifyContent:"center",boxSizing:"border-box",userSelect:"none",fontSize:12,backgroundColor:"#3fbbfe",color:"#fff",fontWeight:"bold"},onClick:()=>c((e=>!e))},"\u6536")),a.createElement("ul",{className:(0,l.Z)(i.k.docs.docSidebarMenu,"menu__list")},a.createElement(V,{items:t,activePath:n,onItemClick:e=>{"category"===e.type&&e.href&&o.toggle(),"link"===e.type&&o.toggle()},level:1})))};function le(e){return a.createElement(te.Zo,{component:ae,props:e})}function oe(){const e=G.findIndex((e=>e.top)),t=G.find((e=>e.top));return a.createElement("div",{style:{margin:"0.5em",display:"block",borderBottom:"1px solid #dedede",paddingBottom:"0.2em",clear:"both"}},a.createElement(ie,{title:t.title,url:t.url,picture:t.picture,top:!0,last:!1}),G.filter(((t,n)=>n!==e)).map(((e,t)=>{let{picture:n,url:l,title:o}=e;return a.createElement(re,{key:l,title:o,url:l,picture:n,i:t})})),a.createElement("div",{style:{display:"flex",justifyContent:"space-between",alignItems:"center",padding:"5px 0"}},a.createElement("span",{style:{fontSize:12,color:"#ccc"}},"\u5408\u4f5c\u5fae\u4fe1\u53f7\uff1aibaiqian"),a.createElement("a",{href:"/docs/donate",style:{color:"#723cff",fontSize:13,fontWeight:"bold"},title:"monksoul@outlook.com"},"\u6210\u4e3a\u8d5e\u52a9\u5546")))}function ie(e){let{picture:t,url:n,last:l,title:o,top:i}=e;return a.createElement("a",{href:n,target:"_blank",title:o,style:{display:"block",marginBottom:l?null:"0.5em",position:"relative",alignItems:"center",boxSizing:"border-box",border:i?"2px solid rgb(255, 176, 46)":void 0}},a.createElement("img",{src:(0,y.Z)(t),style:{display:"block",width:"100%"},loading:"lazy"}),i&&a.createElement("span",{style:{position:"absolute",zIndex:10,top:-16,right:-8}},"\ud83d\udc51"),a.createElement("span",{style:{position:"absolute",display:"block",right:0,bottom:0,zIndex:10,fontSize:12,backgroundColor:"rgba(0,0,0,0.8)",padding:"0 5px"}}))}function re(e){let{picture:t,url:n,title:l,i:o}=e;return a.createElement("a",{href:n,target:"_blank",title:l,style:{display:"inline-block",position:"relative",width:"48.5%",marginRight:o%2!=0?0:8,position:"relative",boxSizing:"border-box"}},a.createElement("img",{src:(0,y.Z)(t),style:{display:"block",width:"100%"},loading:"lazy"}))}const ce=a.memo(le);function se(e){const t=(0,E.i)(),n="desktop"===t||"ssr"===t,l="mobile"===t;return a.createElement(a.Fragment,null,n&&a.createElement(ee,e),l&&a.createElement(ce,e))}const de={expandButton:"expandButton_m80_",expandButtonIcon:"expandButtonIcon_BlDH"};function me(e){let{toggleSidebar:t}=e;return a.createElement("div",{className:de.expandButton,title:(0,u.I)({id:"theme.docs.sidebar.expandButtonTitle",message:"Expand sidebar",description:"The ARIA label and title attribute for expand button of doc sidebar"}),"aria-label":(0,u.I)({id:"theme.docs.sidebar.expandButtonAriaLabel",message:"Expand sidebar",description:"The ARIA label and title attribute for expand button of doc sidebar"}),tabIndex:0,role:"button",onKeyDown:t,onClick:t},a.createElement(S,{className:de.expandButtonIcon}))}const ue={docSidebarContainer:"docSidebarContainer_b6E3",docSidebarContainerHidden:"docSidebarContainerHidden_b3ry",sidebarViewport:"sidebarViewport_Xe31"};function pe(e){let{children:t}=e;const n=(0,d.V)();return a.createElement(a.Fragment,{key:n?.name??"noSidebar"},t)}function be(e){let{sidebar:t,hiddenSidebarContainer:n,setHiddenSidebarContainer:o}=e;const{pathname:r}=(0,f.TH)(),[c,s]=(0,a.useState)(!1),d=(0,a.useCallback)((()=>{c&&s(!1),o((e=>!e))}),[o,c]);return a.createElement("aside",{className:(0,l.Z)(i.k.docs.docSidebarContainer,ue.docSidebarContainer,n&&ue.docSidebarContainerHidden),onTransitionEnd:e=>{e.currentTarget.classList.contains(ue.docSidebarContainer)&&n&&s(!0)}},a.createElement(pe,null,a.createElement("div",{className:(0,l.Z)(ue.sidebarViewport,c&&ue.sidebarViewportHidden)},a.createElement(se,{sidebar:t,path:r,onCollapse:d,isHidden:c}),c&&a.createElement(me,{toggleSidebar:d}))))}const he={docMainContainer:"docMainContainer_gTbr",docMainContainerEnhanced:"docMainContainerEnhanced_Uz_u",docItemWrapperEnhanced:"docItemWrapperEnhanced_czyv"};function ge(e){let{hiddenSidebarContainer:t,children:n}=e;const o=(0,d.V)();return a.createElement("main",{className:(0,l.Z)(he.docMainContainer,(t||!o)&&he.docMainContainerEnhanced)},a.createElement("div",{className:(0,l.Z)("container padding-top--md padding-bottom--lg",he.docItemWrapper,t&&he.docItemWrapperEnhanced)},n))}const fe={docPage:"docPage__5DB",docsWrapper:"docsWrapper_BCFX"};function Ee(e){let{children:t}=e;const n=(0,d.V)(),[l,o]=(0,a.useState)(!1);return a.createElement(m.Z,{wrapperClassName:fe.docsWrapper},a.createElement(g,null),a.createElement("div",{className:fe.docPage},n&&a.createElement(be,{sidebar:n.items,hiddenSidebarContainer:l,setHiddenSidebarContainer:o}),a.createElement(ge,{hiddenSidebarContainer:l},t)))}var ke=n(4972),ye=n(197);function ve(e){const{versionMetadata:t}=e;return a.createElement(a.Fragment,null,a.createElement(ye.Z,{version:t.version,tag:(0,r.os)(t.pluginId,t.version)}),a.createElement(o.d,null,t.noIndex&&a.createElement("meta",{name:"robots",content:"noindex, nofollow"})))}function Se(e){const{versionMetadata:t}=e,n=(0,c.hI)(e);if(!n)return a.createElement(ke.default,null);const{docElement:r,sidebarName:m,sidebarItems:u}=n;return a.createElement(a.Fragment,null,a.createElement(ve,e),a.createElement(o.FG,{className:(0,l.Z)(i.k.wrapper.docsPages,i.k.page.docsDocPage,e.versionMetadata.className)},a.createElement(s.q,{version:t},a.createElement(d.b,{name:m,items:u},a.createElement(Ee,null,r)))))}},4972:(e,t,n)=>{n.r(t),n.d(t,{default:()=>r});var a=n(7294),l=n(5999),o=n(1944),i=n(179);function r(){return a.createElement(a.Fragment,null,a.createElement(o.d,{title:(0,l.I)({id:"theme.NotFound.title",message:"Page Not Found"})}),a.createElement(i.Z,null,a.createElement("main",{className:"container margin-vert--xl"},a.createElement("div",{className:"row"},a.createElement("div",{className:"col col--6 col--offset-3"},a.createElement("h1",{className:"hero__title"},a.createElement(l.Z,{id:"theme.NotFound.title",description:"The title of the 404 page"},"Page Not Found")),a.createElement("p",null,a.createElement(l.Z,{id:"theme.NotFound.p1",description:"The first paragraph of the 404 page"},"We could not find what you were looking for.")),a.createElement("p",null,a.createElement(l.Z,{id:"theme.NotFound.p2",description:"The 2nd paragraph of the 404 page"},"Please contact the owner of the site that linked you to the original URL and let them know their link is broken.")))))))}}}]);