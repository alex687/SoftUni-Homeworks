define(["Item", "Section", "Container"], function (Item, Section, Container) {
    var Factory = {};
    Factory.Container = Container;
    Factory.Item = Item;
    Factory.Section = Section;

    return (function(){ return Factory;}());
});