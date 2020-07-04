module App

open Browser
open Feliz
open Elmish
open Feliz.UseMediaQuery

let useResponsiveExample = React.functionComponent(fun () ->
    let width = React.useResponsive(defaultBreakpoints)

    Html.div [
        prop.text (width |> string)
    ])

let useMediaQueryExample = React.functionComponent(fun () ->
    let isMax500 = React.useMediaQuery("(max-width: 500px)")

    Html.div [
        if isMax500 then 
            prop.text "500px or less"
        else
            prop.text "More than 500px"
    ])

let render = React.functionComponent(fun () ->
    Html.div [
        prop.style [
            style.padding 100
            style.display.flex
            style.flexDirection.column
            style.alignItems.center            
            style.justifyContent.center
            style.backgroundColor.beige
        ]
        prop.children [
            useResponsiveExample ()
            useMediaQueryExample ()
        ]
    ]
)

ReactDOM.render(render, document.getElementById "feliz-app")