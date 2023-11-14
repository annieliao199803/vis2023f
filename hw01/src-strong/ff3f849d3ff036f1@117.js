function _1(md){return(
md`# HW1 strong baseline`
)}

function _data1(__query,FileAttachment,invalidation){return(
__query(FileAttachment("data@1.csv"),{from:{table:"data"},sort:[],slice:{to:null,from:null},filter:[],select:{columns:null}},invalidation)
)}

function _plot2(Inputs){return(
Inputs.form({
	mt:  Inputs.range([0, 100], {label: "marginTop", step: 1}),
	mr:  Inputs.range([0, 100], {label: "marginRight", step: 1}),
	mb:  Inputs.range([0, 100], {label: "marginBottom", step: 1}),
	ml:  Inputs.range([0, 100], {label: "marginLeft", step: 1}),
})
)}

async function _4(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業一",
      fill: "#164863",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _5(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業二",
      fill: "#427D9D",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _6(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業三",
      fill: "#9BBEC8",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _7(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業三",
      fill: "#DDF2FD",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _8(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業四",
      fill: "#86A789",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _9(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業五",
      fill: "#B2C8BA",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _10(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業六",
      fill: "#D2E3C8",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _11(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業七",
      fill: "#EBF3E8",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _12(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業八",
      fill: "#04364A",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _13(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業九",
      fill: "#176B87",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

async function _14(Plot,FileAttachment){return(
Plot.plot({
  marks: [
    Plot.barY(await FileAttachment("data@1.csv").csv({ typed: "auto" }), {
      x: "學號",
      y: "作業十",
      fill: "#64CCC5",
      tip: true
    }),
    Plot.ruleY([0])
  ]
})
)}

export default function define(runtime, observer) {
  const main = runtime.module();
  function toString() { return this.url; }
  const fileAttachments = new Map([
    ["data@1.csv", {url: new URL("./data.csv", import.meta.url), mimeType: "text/csv", toString}]
  ]);
  main.builtin("FileAttachment", runtime.fileAttachments(name => fileAttachments.get(name)));
  main.variable(observer()).define(["md"], _1);
  main.variable(observer("data1")).define("data1", ["__query","FileAttachment","invalidation"], _data1);
  main.variable(observer("viewof plot2")).define("viewof plot2", ["Inputs"], _plot2);
  main.variable(observer("plot2")).define("plot2", ["Generators", "viewof plot2"], (G, _) => G.input(_));
  main.variable(observer()).define(["Plot","FileAttachment"], _4);
  main.variable(observer()).define(["Plot","FileAttachment"], _5);
  main.variable(observer()).define(["Plot","FileAttachment"], _6);
  main.variable(observer()).define(["Plot","FileAttachment"], _7);
  main.variable(observer()).define(["Plot","FileAttachment"], _8);
  main.variable(observer()).define(["Plot","FileAttachment"], _9);
  main.variable(observer()).define(["Plot","FileAttachment"], _10);
  main.variable(observer()).define(["Plot","FileAttachment"], _11);
  main.variable(observer()).define(["Plot","FileAttachment"], _12);
  main.variable(observer()).define(["Plot","FileAttachment"], _13);
  main.variable(observer()).define(["Plot","FileAttachment"], _14);
  return main;
}
