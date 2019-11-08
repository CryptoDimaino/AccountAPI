function MoveSidebarNav()
{
  var sidebar = document.getElementById('sidebar');
    var mainContent = document.getElementById('main-content');
    if(sidebar.classList.contains('active'))
    {
      document.getElementById('main-content').className = "expanded";
    }
    document.getElementById('sidenavbar-postion').onclick = function() {
        sidebar.classList.toggle('active');
        mainContent.classList.toggle('expanded');
    };
}
