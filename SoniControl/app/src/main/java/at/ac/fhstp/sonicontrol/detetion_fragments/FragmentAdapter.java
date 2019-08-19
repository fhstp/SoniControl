package at.ac.fhstp.sonicontrol.detetion_fragments;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import java.util.ArrayList;
import java.util.List;

public class FragmentAdapter extends FragmentPagerAdapter {
    private List<Fragment> Fragment = new ArrayList<>(); //Fragment List
    private List<String> NamePage = new ArrayList<>(); // Fragment Name List
    public FragmentAdapter(FragmentManager manager) {
        super(manager);
    }
    public void add(Fragment Frag, String Title) {
        Fragment.add(Frag);
        NamePage.add(Title);
    }
    @Override
    public android.support.v4.app.Fragment getItem(int position) {
        return Fragment.get(position);
    }
    @Override
    public CharSequence getPageTitle(int position) {
        return NamePage.get(position);
    }
    @Override
    public int getCount() {
        return 4;
    }
}
